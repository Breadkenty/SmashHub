using AutoMapper;
using SmashCombos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashCombos.Core.Cqrs.Characters.GetCharacters
{
    public class GetCharactersProfile : Profile
    {
        public GetCharactersProfile()
        {
            CreateMap<Character, GetCharactersResponse>();
        }
    }
}
