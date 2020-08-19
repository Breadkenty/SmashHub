using AutoMapper;
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
            CreateMap<Character, GetCharacterResponse>();
        }
    }
}
