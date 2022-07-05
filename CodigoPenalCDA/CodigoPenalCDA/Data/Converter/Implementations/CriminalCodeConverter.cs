using CodigoPenalCDA.Data.Converter.Contract;
using CodigoPenalCDA.Data.VO;
using CodigoPenalCDA.Model;
using System.Collections.Generic;
using System.Linq;

namespace CodigoPenalCDA.Data.Converter.Implementations
{
    public class CriminalCodeConverter : IParser<CriminalCodeVO, CriminalCode>, IParser<CriminalCode, CriminalCodeVO>
    {
        public CriminalCode Parse(CriminalCodeVO origin)
        {
            if (origin == null) return null;
            return new CriminalCode
            {
                Id = origin.Id,
                Name = origin.Name,
                Description = origin.Description,
                Penalty = origin.Penalty,
                PrisonTime = origin.PrisonTime,
                StatusId = origin.StatusId,
                CreateDate = origin.CreateDate,
                UpdateDate = origin.UpdateDate,
                CreateUserId = origin.CreateUserId,
                UpdateUserId = origin.UpdateUserId
            };
        }

        public List<CriminalCode> Parse(List<CriminalCodeVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public CriminalCodeVO Parse(CriminalCode origin)
        {
            if (origin == null) return null;
            return new CriminalCodeVO
            {
                Id = origin.Id,
                Name = origin.Name,
                Description = origin.Description,
                Penalty = origin.Penalty,
                PrisonTime = origin.PrisonTime,
                StatusId = origin.StatusId,
                CreateDate = origin.CreateDate,
                UpdateDate = origin.UpdateDate,
                CreateUserId = origin.CreateUserId,
                UpdateUserId = origin.UpdateUserId
            };
        }

        public List<CriminalCodeVO> Parse(List<CriminalCode> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}