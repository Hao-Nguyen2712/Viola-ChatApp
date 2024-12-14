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
    public class GetUserHandler : IRequestHandler<GetUserQuerry, IEnumerable<User>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<User>> Handle(GetUserQuerry request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.User.GetUsers();
        }
    }
}
