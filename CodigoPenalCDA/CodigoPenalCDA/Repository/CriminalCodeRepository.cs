using System;
using System.Collections.Generic;
using System.Linq;
using CodigoPenalCDA.Model;
using CodigoPenalCDA.Model.Context;
using CodigoPenalCDA.Repository.Generic;

namespace CodigoPenalCDA.Repository
{
    public class CriminalCodeRepository : GenericRepository<CriminalCode>, ICriminalCodeRepository
    {
        public CriminalCodeRepository(MySQLContext context) : base(context) {}

        public List<CriminalCode> FindByName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                return _context.CriminalCodes.Where(p => p.Name.Contains(name)).ToList();
            }

            return null;
        }
    }
}