using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viola.Domain.Models;
using Viola.Domain.Repositories;
using Viola.Persistance.DBContext;

namespace Viola.Persistance.Repositories
{
    public class UserTokenRepository : IUserTokenRepository
    {
        private readonly ViolaContext _context;

        public UserTokenRepository(ViolaContext context)
        {
            _context = context;
        }

        // Add refreshtoken in Database
        public async Task CreateToken(UserToken userToken)
        {
            await _context.UserTokens.AddAsync(userToken);
        }
    }
}
