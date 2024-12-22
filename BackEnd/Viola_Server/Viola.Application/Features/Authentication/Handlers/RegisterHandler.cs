using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Viola.Application.Features.Authentication.Commands;
using Viola.Application.Interface;
using Viola.Domain.Entities;
using Viola.Domain.Repositories;

namespace Viola.Application.Features.Authentication.Handlers
{
    public class RegisterHandler : IRequestHandler<RegisterCommand>
    {
        private readonly IAuthenService authenService;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public RegisterHandler(IAuthenService authenService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.authenService = authenService;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            if (request.Email == null || request.Password == null)
            {
                throw new ArgumentNullException();
            }
            var emailAuth = await authenService.Register(request.Email, request.Password);
            if (emailAuth == null)
            {
                throw new Exception("Register failed");
            }

            await unitOfWork.User.CreateUser(new User { Email = emailAuth });
            await unitOfWork.SaveChangesAsync();
        }
    }
}
