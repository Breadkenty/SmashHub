using AutoMapper;
using SmashCombos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashCombos.Core.Cqrs.Characters.PostCharacter
{
    public class PostCharacterProfile : Profile
    {
        public PostCharacterProfile()
        {
            CreateMap<Character, PostCharacterResponse>();
        }
    }
}
