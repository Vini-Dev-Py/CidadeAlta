using CodigoPenalCDA.Data.Converter.Implementations;
using CodigoPenalCDA.Data.VO;
using CodigoPenalCDA.Model;
using CodigoPenalCDA.Repository;
using CodigoPenalCDA.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace CodigoPenalCDA.Business.Implementations
{
    public class CriminalCodeBusinessImplementations : ICriminalCodeBusiness
    {
        private readonly IRepository<CriminalCode> _repository;

        private readonly IRepository<Status> _repositoryStatus;

        private readonly CriminalCodeConverter _converter;

        private readonly ITokenService _tokenService;

        public CriminalCodeBusinessImplementations(IRepository<CriminalCode> repository, IRepository<Status> repositoryStatus)
        {
            _repository = repository;
            _repositoryStatus = repositoryStatus;
            _converter = new CriminalCodeConverter();
        }

        public CriminalCodeVO Create(CriminalCodeVO criminalCode, string token)
        {
            var criminalEntity = _converter.Parse(criminalCode);

            Random randomNumber = new Random();

            var statusEntity = new Status()
            {
                Id = randomNumber.Next(10000),
                Name = criminalEntity.Name
            };
            
            criminalEntity.StatusId = statusEntity.Id;
            criminalEntity.CreateDate = DateTime.Now;

            var handler = new JwtSecurityTokenHandler();

            var jsonToken = handler.ReadToken(token);

            var principal = jsonToken as JwtSecurityToken;

            var claim = principal.Claims.Where(x => x.Type == "iduser").FirstOrDefault();

            criminalEntity.CreateUserId = int.Parse(claim.Value);
            
            statusEntity = _repositoryStatus.Create(statusEntity);
            
            criminalEntity = _repository.Create(criminalEntity);
            return _converter.Parse(criminalEntity);
        }

        public CriminalCodeVO Update(CriminalCodeVO criminalCode, string token)
        {
            var criminalEntity = _converter.Parse(criminalCode);

            criminalEntity.UpdateDate = DateTime.Now;

            var handler = new JwtSecurityTokenHandler();

            var jsonToken = handler.ReadToken(token);

            var principal = jsonToken as JwtSecurityToken;

            var claim = principal.Claims.Where(x => x.Type == "iduser").FirstOrDefault();

            criminalEntity.UpdateUserId = int.Parse(claim.Value);

            criminalEntity = _repository.Update(criminalEntity);
            return _converter.Parse(criminalEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<CriminalCodeVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public CriminalCodeVO FindByID(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }
    }
}