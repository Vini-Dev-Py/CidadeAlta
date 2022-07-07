using System.Collections.Generic;
using CodigoPenalCDA.Model;

namespace CodigoPenalCDA.Repository
{
    public interface ICriminalCodeRepository
    {
        List<CriminalCode> FindByName(string name);
    }
}