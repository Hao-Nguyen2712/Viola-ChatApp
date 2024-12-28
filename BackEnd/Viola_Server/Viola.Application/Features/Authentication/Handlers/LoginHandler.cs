using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viola.Application.DTOs.Response;
using Viola.Application.Features.Authentication.Commands;
using Viola.Application.Interface;
using Viola.Domain.Entities;
using Viola.Domain.Repositories;

namespace Viola.Application.Features.Authentication.Handlers
{
    public class LoginHandler : IRequestHandler<LoginCommand, TokenDTO>
    {
        private readonly IAuthenService authenService;
        private readonly IUnitOfWork unitOfWork;
        public LoginHandler(IAuthenService authenService, IUnitOfWork unitOfWork)
        {
            this.authenService = authenService;
            this.unitOfWork = unitOfWork;
        }
        public async Task<TokenDTO> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var (accessToken, refreshToken) = await authenService.Login(request.Email, request.Password);
            await unitOfWork.UserToken.CreateToken(refreshToken);
            try
            {
                await unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }

            return new TokenDTO
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken.Value,
            };
        }
    }
}
