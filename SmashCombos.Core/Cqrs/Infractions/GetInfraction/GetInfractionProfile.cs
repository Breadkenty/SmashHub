using AutoMapper;
using SmashCombos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashCombos.Core.Cqrs.Infractions.GetInfraction
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
