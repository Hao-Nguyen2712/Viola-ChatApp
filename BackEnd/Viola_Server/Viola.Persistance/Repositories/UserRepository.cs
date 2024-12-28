using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viola.Domain.Entities;
using Viola.Domain.Repositories;
using Viola.Persistance.DBContext;

namespace Viola.Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ViolaContext _context;

        public UserRepository(ViolaContext context)
        {
            _context = context;
        }
        public async Task CreateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            
            await _context.Users.AddAsync(user);
        }
    }
}
