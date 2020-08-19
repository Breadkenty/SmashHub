using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Characters.GetCharacters
{
    public class GetCharactersRequest : IRequest<IEnumerable<CharacterResponse>>
    {
        public string Filter { get; set; }
    }
}
