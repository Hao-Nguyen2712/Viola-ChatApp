using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viola.Domain.Entities;
using Viola.Domain.Interface;

namespace Viola.Application.Commands.Handler
{
    public class AddUserHandler : IRequestHandler<AddUserCommand, int>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public AddUserHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<int> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            //var user = mapper.Map<User>(request);
            //if (user == null)
            //{
            //    throw new ApplicationException("There is an issue with the mapping");
            //}
            //await unitOfWork.User.CreateUser(user);
            //await unitOfWork.SaveChangesAsync(cancellationToken);
            return 1;
        }
    }
}
