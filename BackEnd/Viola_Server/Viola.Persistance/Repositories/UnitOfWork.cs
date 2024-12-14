using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viola.Domain.Interface;

namespace Viola.Persistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ViolaContext _context;
        public IUserRepository User { get;  }

        public UnitOfWork(ViolaContext context , IUserRepository user)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            User = user ?? throw new ArgumentNullException(nameof(user));
        }

        public void Dispose()
        {
           _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
           await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
