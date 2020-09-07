using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Characters.GetCharacters
{
    public class GetCharactersResponse : ResponseBase<IEnumerable<CharacterDto>>
    {
    }
}
