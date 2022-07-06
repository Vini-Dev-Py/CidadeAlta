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
    public class StatusBusinessImplementation : IStatusBusiness
    {
        private readonly IRepository<Status> _repository;

        private readonly StatusConverter _converter;

        private readonly ITokenService _tokenService;

        public StatusBusinessImplementation(IRepository<Status> repository)
        {
            _repository = repository;
            _converter = new StatusConverter();
        }

        public StatusVO Create(StatusVO status)
        {
            var statusEntity = _converter.Parse(status);
            statusEntity = _repository.Create(statusEntity);
            return _converter.Parse(statusEntity);
        }
        
        public StatusVO Update(StatusVO status)
        {
            var statusEntity = _converter.Parse(status);
            statusEntity = _repository.Update(statusEntity);
            return _converter.Parse(statusEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<StatusVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public StatusVO FindByID(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        
    }
}