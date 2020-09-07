using AutoMapper;
using Smash_Combos.Core.Cqrs.Characters.GetCharacters;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Characters.GetCharacter
{
    public class GetCharacterProfile : Profile
    {
        public GetCharacterProfile()
        {
            CreateMap<Character, CharacterDto>();
            CreateMap<Combo, ComboDto>();
            CreateMap<User, UserDto>();
        }
    }
}
