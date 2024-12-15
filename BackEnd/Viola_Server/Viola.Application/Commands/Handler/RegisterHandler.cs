using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viola.Application.Common.DTOs;
using Viola.Domain.Entities;
using Viola.Domain.Interface;

namespace Viola.Application.Commands.Handler
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, string>
    {
        private readonly IAuthenticateService _authenticateService;
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public RegisterHandler(IAuthenticateService authenticateService, IUnitOfWork unitOfWork , IMapper mapper)
        {
            _authenticateService = authenticateService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ApplicationException("There is an issue with the request");
            }

            var identityUser = _authenticateService.Register(request.Email, request.Password);
            var user = new UserRegisterDTO
            {
                UserId = identityUser.Result[0],
                Email = identityUser.Result[1],
                Password = identityUser.Result[2],
                FullName = "Anonymous"
            };

            var userEntity = _mapper.Map<User>(user);
            var result = await _unitOfWork.User.CreateUser(userEntity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result.Email;
        }
    }
}
