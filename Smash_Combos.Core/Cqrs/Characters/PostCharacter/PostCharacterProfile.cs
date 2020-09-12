using AutoMapper;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Characters.PostCharacter
{
    public class PostCharacterProfile : Profile
    {
        public PostCharacterProfile()
        {
            CreateMap<Character, PostCharacterResponse>();
        }
    }
}
