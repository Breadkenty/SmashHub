using AutoMapper;
using SmashCombos.Domain.Models;

namespace SmashCombos.Core.Cqrs.Combos.GetCombo
{
    public class GetComboProfile : Profile
    {
        public GetComboProfile()
        {
            CreateMap<Combo, GetComboResponse>();
            CreateMap<Comment, CommentDto>();
            CreateMap<User, UserDto>();
            CreateMap<Character, CharacterDto>();
        }
    }
}
