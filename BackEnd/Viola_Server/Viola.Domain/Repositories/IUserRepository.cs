using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viola.Domain.Entities;

namespace Viola.Domain.Repositories
{
    public interface IUserRepository
    {
        Task CreateUser(User user);
    }
}
