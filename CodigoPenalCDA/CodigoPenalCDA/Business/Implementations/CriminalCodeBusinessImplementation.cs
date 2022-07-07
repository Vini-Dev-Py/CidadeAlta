using CodigoPenalCDA.Data.Converter.Implementations;
using CodigoPenalCDA.Data.VO;
using CodigoPenalCDA.Hypermedia.Utils;
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

        private readonly ICriminalCodeRepository _repositoryCriminalCode;

        private readonly IRepository<Status> _repositoryStatus;

        private readonly CriminalCodeConverter _converter;

        private readonly ITokenService _tokenService;

        public CriminalCodeBusinessImplementations(IRepository<CriminalCode> repository, IRepository<Status> repositoryStatus, ICriminalCodeRepository criminalCodeRepository)
        {
            _repository = repository;
            _repositoryStatus = repositoryStatus;
            _repositoryCriminalCode = criminalCodeRepository;
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

        public List<CriminalCodeVO> FindByName(string name)
        {
            return _converter.Parse(_repositoryCriminalCode.FindByName(name));
        }

        public PagedSearchVO<CriminalCodeVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        {
            var sort = (!string.IsNullOrWhiteSpace(sortDirection)) && !sortDirection.Equals("desc") ? "asc" : "desc";
            var size = (pageSize < 1) ? 10: pageSize;
            var offset = page > 0 ? (page - 1) * size : 0;

            string query = @"select * from criminalcode c where 1 = 1 ";

            if (!string.IsNullOrWhiteSpace(name)) query = query + $" and c.name like '%{name}%' ";

            query = query + $" order by c.name {sort} limit {size} offset {offset}";
            

            string countQuery = @"select count(*) from criminalcode c where 1 = 1 ";

            if (!string.IsNullOrWhiteSpace(name)) countQuery = countQuery + $" and c.name like '%{name}%' ";

            var criminalCode = _repository.FindWithPagedSearch(query);

            int totalResults = _repository.GetCount(countQuery);

            return new PagedSearchVO<CriminalCodeVO> {
                CurrentPage = page,
                List = _converter.Parse(criminalCode),
                PageSize = size,
                SortDirections = sort,
                TotalResults = totalResults
            };
        }
    }
}