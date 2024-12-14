using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viola.Domain.Entities;
using Viola.Domain.Interface;

namespace Viola.Application.Queries.Handler
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuerry, User>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<User> Handle(GetUserByIdQuerry request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.User.GetUserById(request.id);
        }
    }
}
