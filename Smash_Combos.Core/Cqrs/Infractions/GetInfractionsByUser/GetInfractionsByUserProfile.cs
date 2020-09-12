using AutoMapper;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Infractions.GetInfractionsByUser
{
    public class GetInfractionsByUserProfile : Profile
    {
        public GetInfractionsByUserProfile()
        {
            CreateMap<Infraction, GetInfractionsByUserResponse>();
            CreateMap<User, UserDto>();
        }
    }
}
