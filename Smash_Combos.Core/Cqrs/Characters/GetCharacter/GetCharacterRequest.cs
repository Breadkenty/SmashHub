using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Characters.GetCharacter
{
    public class GetCharacterRequest : IRequest<CharacterResponse>
    {
        public string VariableName { get; set; }
    }
}
