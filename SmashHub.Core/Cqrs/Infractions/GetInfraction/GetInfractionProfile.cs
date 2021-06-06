using AutoMapper;
using SmashHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashHub.Core.Cqrs.Infractions.GetInfraction
{
    public class GetInfractionProfile : Profile
    {
        public GetInfractionProfile()
        {
            CreateMap<Infraction, GetInfractionResponse>();
            CreateMap<User, UserDto>();
        }
    }
}
