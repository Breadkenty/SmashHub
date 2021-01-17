using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmashCombos.Core.Services;
using SmashCombos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmashCombos.Core.Cqrs.Infractions.PutInfraction
{
    public class PutInfractionRequestHandler : IRequestHandler<PutInfractionRequest, PutInfractionResponse>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public PutInfractionRequestHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PutInfractionResponse> Handle(PutInfractionRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == request.CurrentUserId);

            if (currentUser == null)
                throw new KeyNotFoundException($"User with id {request.CurrentUserId} does not exist");

            var infraction = await _dbContext.Infractions.Where(infraction => infraction.Id == request.InfractionId).FirstOrDefaultAsync();

            if (infraction == null)
                throw new KeyNotFoundException($"Infraction with id {request.InfractionId} does not exist");

            if (currentUser.UserType == UserType.Moderator || currentUser.UserType == UserType.Admin)
            {
                infraction.BanDuration = request.BanDuration;
                infraction.Points = DeterminePoints(request);
                infraction.Category = request.Category;
                infraction.Body = request.Body;

                _dbContext.Entry(infraction).State = EntityState.Modified;

                await _dbContext.SaveChangesAsync(CancellationToken.None);
                return new PutInfractionResponse();
            }
            else
            {
                throw new SecurityException("Not authorized to edit infractions");
            }
        }

        private int? DeterminePoints(PutInfractionRequest request)
        {
            if (request.Points != null)
                return request.Points;

            return request.Category switch
            {
                InfractionCategory.Spam => 1,
                InfractionCategory.Harassment => 2,
                InfractionCategory.Inappropriate => 2,
                InfractionCategory.UnauthorizedPromotion => 1,
                _ => null,
            };
        }
    }
}
