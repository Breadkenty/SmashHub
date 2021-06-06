using MediatR;

namespace SmashHub.Core.Cqrs.Combos.GetCombo
{
    public class GetComboRequest : IRequest<GetComboResponse>
    {
        public int ComboId { get; set; }
    }
}
