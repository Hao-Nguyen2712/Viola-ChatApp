using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viola.Application.DTOs.Response;

namespace Viola.Application.Features.Authentication.Commands
{
    public record LoginCommand : IRequest<TokenDTO>
    {
        public string? Email { get; set; }
        public string? Password
        {
            get; set;
        }
    }
}
