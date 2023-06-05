using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class DenominationRepository //: IDenominationRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public DenominationRepository(RepositoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Denomination> GetAllDenominations()
        {
            return _dbContext.Denominations.ToList();
        }
    }

}
