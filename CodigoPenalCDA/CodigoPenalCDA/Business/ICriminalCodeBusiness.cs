using System.Collections.Generic;
using CodigoPenalCDA.Data.VO;

namespace CodigoPenalCDA.Business
{
    public interface ICriminalCodeBusiness
    {
        CriminalCodeVO Create(CriminalCodeVO criminalCode, string token);
        CriminalCodeVO FindByID(long id);
        List<CriminalCodeVO> FindAll();
        CriminalCodeVO Update(CriminalCodeVO criminalCode);
        void Delete(long id);
    }
}