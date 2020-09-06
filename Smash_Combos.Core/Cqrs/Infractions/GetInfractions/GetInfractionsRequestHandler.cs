using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Smash_Combos.Core.Services;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Smash_Combos.Core.Cqrs.Infractions.GetInfractions
{
    public class GetInfractionsRequestHandler : IRequestHandler<GetInfractionsRequest, GetInfractionsResponse>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetInfractionsRequestHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetInfractionsResponse> Handle(GetInfractionsRequest request, CancellationToken cancellationToken)
        {
            User user = null;
            try
            {
                user = await _dbContext.Users.Where(user => user.Id == request.ModeratorId).SingleOrDefaultAsync();
            }
            catch (InvalidOperationException)
            {
                return new GetInfractionsResponse { ResponseStatus = ResponseStatus.Error, ResponseMessage = "Multiple Users with same Id found" };
            }

            if (user == null)
                return new GetInfractionsResponse { ResponseStatus = ResponseStatus.BadRequest, ResponseMessage = "User does not exist" };

            if (user.UserType == UserType.Moderator || user.UserType == UserType.Admin)
            {
                var infractions = await _dbContext.Infractions
                    .Include(infraction => infraction.User)
                    .Include(infraction => infraction.Moderator)
                    .ToListAsync();

                return new GetInfractionsResponse { Data = _mapper.Map<IEnumerable<InfractionDto>>(infractions), ResponseStatus = ResponseStatus.Ok, ResponseMessage = $"{infractions.Count} found" };
            }
            else
            {
                return new GetInfractionsResponse { ResponseStatus = ResponseStatus.NotAuthorized, ResponseMessage = "Not authorized to get infractions" };
            }
        }
    }
}
