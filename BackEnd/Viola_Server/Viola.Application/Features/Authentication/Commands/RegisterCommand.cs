﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viola.Application.Features.Authentication.Commands
{
    public record RegisterCommand : IRequest
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
