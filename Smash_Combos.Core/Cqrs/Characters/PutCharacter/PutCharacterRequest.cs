using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Characters.PutCharacter
{
    public class PutCharacterRequest : IRequest<PutCharacterResponse>
    {
        public int CurrentUserId { get; set; }
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public string VariableName { get; set; }
        public int YPosition { get; set; }
        public decimal ReleaseOrder { get; set; }
    }
}
