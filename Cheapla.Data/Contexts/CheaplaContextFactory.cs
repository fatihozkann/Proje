using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheapla.Data.Contexts
{
    internal class CheaplaContextFactory : IDesignTimeDbContextFactory<CheaplaContext>
    {
        public CheaplaContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CheaplaContext>(); optionsBuilder.UseSqlServer("server=LAPTOP-PQI1145Q; database=Cheapla; Trusted_Connection=true");
            return new CheaplaContext(optionsBuilder.Options);
        }
    }
}
