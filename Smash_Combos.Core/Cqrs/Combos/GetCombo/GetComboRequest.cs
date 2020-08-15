using MediatR;

namespace Smash_Combos.Core.Cqrs.Combos.GetCombo
{
    public class GetComboRequest : IRequest<GetComboResponse>
    {
        public int ComboID { get; set; }
    }
}
