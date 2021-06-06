using AutoMapper;
using SmashHub.Domain.Models;

namespace SmashHub.Core.Cqrs.Combos.GetCombo
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
