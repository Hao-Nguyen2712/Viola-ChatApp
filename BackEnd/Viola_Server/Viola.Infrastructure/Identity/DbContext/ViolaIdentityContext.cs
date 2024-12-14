using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Viola.Infrastructure.Identity.DbContext
{
    public class ViolaIdentityContext : IdentityDbContext<IdentityUser>
    {
        public ViolaIdentityContext(DbContextOptions<ViolaIdentityContext> options)
            : base(options)
        {
        }
        protected ViolaIdentityContext(DbContextOptions options)
           : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }

  
}

