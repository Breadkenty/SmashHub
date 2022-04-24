using AutoMapper;
using SmashHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashHub.Core.Cqrs.Characters.GetCharacters
{
    public class GetCharactersProfile : Profile
    {
        public GetCharactersProfile()
        {
            CreateMap<Character, GetCharactersResponse>();
        }
    }
}
