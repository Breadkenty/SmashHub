using AutoMapper;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Infractions.GetInfractions
{
    public class GetInfractionsProfile : Profile
    {
        public GetInfractionsProfile()
        {
            CreateMap<Infraction, GetInfractionsResponse>();
            CreateMap<User, UserDto>();
        }
    }
}
