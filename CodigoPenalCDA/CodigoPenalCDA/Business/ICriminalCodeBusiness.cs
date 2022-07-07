using System.Collections.Generic;
using CodigoPenalCDA.Data.VO;
using CodigoPenalCDA.Hypermedia.Utils;

namespace CodigoPenalCDA.Business
{
    public interface ICriminalCodeBusiness
    {
        CriminalCodeVO Create(CriminalCodeVO criminalCode, string token);
        CriminalCodeVO FindByID(long id);
        List<CriminalCodeVO> FindByName(string name);
        List<CriminalCodeVO> FindAll();
        PagedSearchVO<CriminalCodeVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);
        CriminalCodeVO Update(CriminalCodeVO criminalCode, string token);
        void Delete(long id);
    }
}