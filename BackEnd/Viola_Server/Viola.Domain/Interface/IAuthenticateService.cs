using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viola.Domain.Interface
{
    public interface IAuthenticateService
    {
        public Task<List<string>> Register(string email, string password);
    }
}
