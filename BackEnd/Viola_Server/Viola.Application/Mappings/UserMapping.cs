using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viola.Application.Features.Authentication.Commands;
using Viola.Domain.Entities;

namespace Viola.Application.Mappings
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<User, RegisterCommand>().ReverseMap();
        }
    }
}
