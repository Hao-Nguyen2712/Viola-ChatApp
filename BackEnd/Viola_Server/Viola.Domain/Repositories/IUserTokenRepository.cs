using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viola.Domain.Models;

namespace Viola.Domain.Repositories
{
    public interface IUserTokenRepository
    {
        Task CreateToken(UserToken userToken);
        
    }
}
