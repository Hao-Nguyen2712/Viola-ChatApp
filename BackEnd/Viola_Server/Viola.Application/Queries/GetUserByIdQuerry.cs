using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viola.Domain.Entities;

namespace Viola.Application.Queries
{
    public record GetUserByIdQuerry(string id) : IRequest<User>;
}
