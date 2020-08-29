using AutoMapper;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Infractions.PostInfraction
{
    public class PostInfractionProfile : Profile
    {
        public PostInfractionProfile()
        {
            CreateMap<Infraction, PostInfractionResponse>();
            CreateMap<User, UserDto>();
        }
    }
}
