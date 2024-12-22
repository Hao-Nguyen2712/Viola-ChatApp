using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viola.Application.Features.Authentication.Commands;
using Viola.Application.Interface;

namespace Viola.Application.Features.Authentication.Handlers
{
    public class LoginHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IAuthenService  authenService;
        public LoginHandler(IAuthenService authenService)
        {
            this.authenService = authenService;
        }
        public Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
           return authenService.Login(request.Email, request.Password);
        }
    }
}
