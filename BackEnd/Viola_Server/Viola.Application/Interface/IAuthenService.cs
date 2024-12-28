using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viola.Domain.Models;

namespace Viola.Application.Interface
{
    public interface IAuthenService
    {
        Task<string> Register(string email, string password);
        Task<(string, UserToken)> Login(string email, string password);
    }
}
