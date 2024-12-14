using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viola.Domain.Entities;
using Viola.Domain.Interface;

namespace Viola.Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ViolaContext _context;

        public UserRepository(ViolaContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<User> CreateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            await _context.Users.AddAsync(user);
            return user;
        }

        public async Task<User> DeleteUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(a => a.UserId == id);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            _context.Users.Remove(user);
            return user;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(a => a.Email == email) ?? throw new ArgumentNullException(nameof(email));
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id) ?? throw new ArgumentNullException(nameof(id));
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToListAsync() ?? throw new ArgumentNullException(nameof(User));
        }

        public Task<User> UpdateUser(User user)
        {
            var userToUpdate = _context.Users.Attach(user);
            userToUpdate.State = EntityState.Modified;
            return Task.FromResult(user);
        }

    }
}
