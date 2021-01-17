using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashCombos.Core.Cqrs.Characters.GetCharacters
{
    public class GetCharactersRequest : IRequest<IEnumerable<GetCharactersResponse>>
    {
        public string Filter { get; set; }
    }
}
