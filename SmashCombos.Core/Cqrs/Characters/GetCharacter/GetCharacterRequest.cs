using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashCombos.Core.Cqrs.Characters.GetCharacter
{
    public class GetCharacterRequest : IRequest<GetCharacterResponse>
    {
        public string VariableName { get; set; }
    }
}
