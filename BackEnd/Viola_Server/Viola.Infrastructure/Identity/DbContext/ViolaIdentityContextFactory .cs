using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viola.Infrastructure.Identity.DbContext
{
    public class ViolaIdentityContextFactory : IDesignTimeDbContextFactory<ViolaIdentityContext>
    {
        public ViolaIdentityContext CreateDbContext(string[] args)
        {
            var connectionString = "Data Source=DESKTOP-N2G9N3D;Initial Catalog=Viola;User ID=sa;Password=27122003;Encrypt=True;Trust Server Certificate=True";
            var optionsBuilder = new DbContextOptionsBuilder<ViolaIdentityContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ViolaIdentityContext(optionsBuilder.Options);
        }
    }
}
