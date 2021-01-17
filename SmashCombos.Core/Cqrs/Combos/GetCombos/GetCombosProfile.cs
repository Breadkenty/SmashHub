using AutoMapper;
using SmashCombos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashCombos.Core.Cqrs.Combos.GetCombos
{
    class GetCombosProfile : Profile
    {
        public GetCombosProfile()
        {
            CreateMap<Combo, GetCombosResponse>();
            CreateMap<Comment, CommentDto>();
            CreateMap<User, UserDto>();
            CreateMap<Character, CharacterDto>();
        }
    }
}
