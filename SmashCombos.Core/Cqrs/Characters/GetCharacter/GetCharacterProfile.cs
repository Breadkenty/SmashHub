using AutoMapper;
using SmashCombos.Core.Cqrs.Characters.GetCharacters;
using SmashCombos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashCombos.Core.Cqrs.Characters.GetCharacter
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
