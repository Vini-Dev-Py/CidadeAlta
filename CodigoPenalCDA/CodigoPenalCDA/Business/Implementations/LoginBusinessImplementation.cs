using Microsoft.IdentityModel.JsonWebTokens;
using CodigoPenalCDA.Configurations;
using CodigoPenalCDA.Data.Converter.Implementations;
using CodigoPenalCDA.Data.VO;
using CodigoPenalCDA.Repository;
using CodigoPenalCDA.Services;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using CodigoPenalCDA.Model;
using System.Text;
using System.Security.Cryptography;
using System.Linq;

namespace CodigoPenalCDA.Business.Implementations
{
    public class LoginBusinessImplementation : ILoginBusiness
    {
        private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
        private TokenConfiguration _configuration;
        private IUserRepository _repository;
        private readonly IRepository<User> _userRepository;
        private readonly ITokenService _tokenService;
        private readonly UserConverter _converter;

        public LoginBusinessImplementation(TokenConfiguration configuration, IUserRepository repository, ITokenService tokenService, IRepository<User> userRepository)
        {
            _configuration = configuration;
            _repository = repository;
            _tokenService = tokenService;
            _userRepository = userRepository;
            _converter = new UserConverter();
        }

        public TokenVO ValidateCredentials(UserVO userCredentials)
        {
            var user = _repository.ValidateCredentials(userCredentials);
            if (user == null) return null;
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim("iduser", user.Id.ToString()),
            };

            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(_configuration.DaysToExpiry);

            _repository.RefreshUserInfo(user);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);

            Console.WriteLine(accessToken);

            return new TokenVO(
                true,
                createDate.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                accessToken,
                refreshToken
                );
        }

        public TokenVO ValidateCredentials(TokenVO token)
        {
            var accessToken = token.AccessToken;
            var refreshToken = token.RefreshToken;

            var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);

            var username = principal.Identity.Name;

            var claim = principal.Claims.Where(x => x.Type == "iduser").FirstOrDefault();

            Console.WriteLine(claim.Value);

            var user = _repository.ValidateCredentials(username);

            if (user == null ||
                user.RefreshToken != refreshToken ||
                user.RefreshTokenExpiryTime <= DateTime.Now) return null;

            accessToken = _tokenService.GenerateAccessToken(principal.Claims);
            refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;

            _repository.RefreshUserInfo(user);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);

            return new TokenVO(
                true,
                createDate.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                accessToken,
                refreshToken
                );
        }

        public bool RevokeToken(string firstName)
        {
            return _repository.RevokeToken(firstName);
        }

        public UserVO Create(UserVO user)
        {
            var userEntity = _converter.Parse(user);

            Byte[] inputBytes = Encoding.UTF8.GetBytes(userEntity.Password);
            SHA256 sha256 = new SHA256CryptoServiceProvider();
            Byte[] outputBytes = sha256.ComputeHash(inputBytes);

            userEntity.Password = BitConverter.ToString(outputBytes);
            userEntity.UserName = userEntity.UserName.ToLower();

            userEntity = _userRepository.Create(userEntity);
            return _converter.Parse(userEntity);
        }
    }
}