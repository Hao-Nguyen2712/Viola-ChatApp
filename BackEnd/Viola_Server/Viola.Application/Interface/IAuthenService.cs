using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viola.Application.Interface
{
    public interface IAuthenService
    {
        Task<string> Register(string email, string password);
        Task<string> Login(string email, string password);
    }
}
