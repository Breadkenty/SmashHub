using AutoMapper;
using SmashHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashHub.Core.Cqrs.Infractions.GetInfractionsByUser
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
