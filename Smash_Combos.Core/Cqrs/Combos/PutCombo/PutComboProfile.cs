using AutoMapper;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Combos.PutCombo
{
    public class PutComboProfile : Profile
    {
        public PutComboProfile()
        {
            CreateMap<Combo, ComboDto>();
            CreateMap<User, UserDto>();
            CreateMap<Comment, CommentDto>();
        }
    }
}
