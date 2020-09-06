using AutoMapper;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Infractions.GetInfraction
{
    public class GetInfractionProfile : Profile
    {
        public GetInfractionProfile()
        {
            CreateMap<Infraction, InfractionDto>();
            CreateMap<User, UserDto>();
        }
    }
}
