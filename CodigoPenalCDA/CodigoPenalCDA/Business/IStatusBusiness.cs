using System.Collections.Generic;
using CodigoPenalCDA.Data.VO;

namespace CodigoPenalCDA.Business
{
    public interface IStatusBusiness
    {
        StatusVO Create(StatusVO status);
        StatusVO FindByID(long id);
        List<StatusVO> FindAll();
        StatusVO Update(StatusVO status);
        void Delete(long id);
    }
}