using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Viola.Domain.Models;


namespace Viola.Infrastructure.Identity.DBContext
{
    public class ViolaIdentityDbContext : IdentityDbContext<IdentityUser>
    {
      
        public ViolaIdentityDbContext(DbContextOptions<ViolaIdentityDbContext> options)
            : base(options)
        {
        }
        protected ViolaIdentityDbContext(DbContextOptions options)
           : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
    
        }
    }
}
