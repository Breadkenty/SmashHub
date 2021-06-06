using AutoMapper;
using SmashHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashHub.Core.Cqrs.Combos.PostCombo
{
    public class PostComboProfile : Profile
    {
        public PostComboProfile()
        {
            CreateMap<Combo, PostComboResponse>();
            CreateMap<Comment, CommentDto>();
            CreateMap<User, UserDto>();
            CreateMap<Character, CharacterDto>();
        }
    }
}
