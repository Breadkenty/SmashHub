using AutoMapper;
using SmashHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashHub.Core.Cqrs.Infractions.GetInfractions
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
