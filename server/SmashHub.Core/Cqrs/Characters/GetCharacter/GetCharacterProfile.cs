using AutoMapper;
using SmashHub.Core.Cqrs.Characters.GetCharacters;
using SmashHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashHub.Core.Cqrs.Characters.GetCharacter
{
    public class GetCharacterProfile : Profile
    {
        public GetCharacterProfile()
        {
            CreateMap<Character, GetCharacterResponse>();
            CreateMap<Combo, ComboDto>();
            CreateMap<User, UserDto>();
        }
    }
}
