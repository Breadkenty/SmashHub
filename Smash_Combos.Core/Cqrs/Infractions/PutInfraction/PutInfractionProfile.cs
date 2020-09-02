using AutoMapper;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Infractions.PutInfraction
{
    public class PutInfractionProfile : Profile
    {
        public PutInfractionProfile()
        {
            CreateMap<Infraction, InfractionDto>();
            CreateMap<User, UserDto>();
        }
    }
}
