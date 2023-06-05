using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace Persistance
{
    public class RepositoryDbContext : DbContext
    {
     
            public DbSet<Denomination> Denominations { get; set; }
            public DbSet<PayoutCombination> PayoutCombinations { get; set; }
            public DbSet<Customer> Customers { get; set; }

        public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options)
        : base(options)
        {
        }

    }
}