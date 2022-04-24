using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashHub.Core.Cqrs.Infractions.GetInfractionsByUser
{
    public class GetInfractionsByUserRequest : IRequest<IEnumerable<GetInfractionsByUserResponse>>
    {
        public int CurrentUserId { get; set; }
        public string DisplayName { get; set; }
    }
}
