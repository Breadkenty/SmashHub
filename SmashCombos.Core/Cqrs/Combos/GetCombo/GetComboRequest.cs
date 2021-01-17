using MediatR;

namespace SmashCombos.Core.Cqrs.Combos.GetCombo
{
    public class GetComboRequest : IRequest<GetComboResponse>
    {
        public int ComboId { get; set; }
    }
}
