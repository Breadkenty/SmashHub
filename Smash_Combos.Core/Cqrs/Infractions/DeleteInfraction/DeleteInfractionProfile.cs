using AutoMapper;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Infractions.DeleteInfraction
{
    public class DeleteInfractionProfile : Profile
    {
        public DeleteInfractionProfile()
        {
            CreateMap<Infraction, InfractionDto>();
            CreateMap<User, UserDto>();
        }
    }
}
