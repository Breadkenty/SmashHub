using AutoMapper;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Combos.DeleteCombo
{
    public class DeleteComboProfile : Profile
    {
        public DeleteComboProfile()
        {
            CreateMap<Combo, ComboDto>();
        }
    }
}
