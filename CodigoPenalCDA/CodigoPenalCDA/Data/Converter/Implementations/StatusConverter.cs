using CodigoPenalCDA.Data.Converter.Contract;
using CodigoPenalCDA.Data.VO;
using CodigoPenalCDA.Model;
using System.Collections.Generic;
using System.Linq;

namespace CodigoPenalCDA.Data.Converter.Implementations
{
    public class StatusConverter : IParser<StatusVO, Status>, IParser<Status, StatusVO>
    {
        public Status Parse(StatusVO origin)
        {
            if (origin == null) return null;
            return new Status
            {
                Id = origin.Id,
                Name = origin.Name
            };
        }

        public List<Status> Parse(List<StatusVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public StatusVO Parse(Status origin)
        {
            if (origin == null) return null;
            return new StatusVO
            {
                Id = origin.Id,
                Name = origin.Name
            };
        }

        public List<StatusVO> Parse(List<Status> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}