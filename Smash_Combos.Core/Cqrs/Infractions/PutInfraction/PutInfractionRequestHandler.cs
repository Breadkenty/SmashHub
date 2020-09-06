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

namespace Smash_Combos.Core.Cqrs.Infractions.PutInfraction
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
            User user = null;
            try
            {
                user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == request.ModeratorId);
            }
            catch (InvalidOperationException)
            {
                return new PutInfractionResponse { ResponseStatus = ResponseStatus.Error, ResponseMessage = "Multiple Users with same Name found" };
            }

            if(user == null)
                return new PutInfractionResponse { ResponseStatus = ResponseStatus.BadRequest, ResponseMessage = "User does not exist" };

            var infraction = await _dbContext.Infractions.Where(infraction => infraction.Id == request.Id).FirstOrDefaultAsync();

            if (infraction == null)
                return new PutInfractionResponse { ResponseStatus = ResponseStatus.BadRequest, ResponseMessage = "Infraction does not exist" };

            if(user.UserType == UserType.Moderator || user.UserType == UserType.Admin)
            {
                infraction.BanDuration = request.BanDuration;
                infraction.Points = DeterminePoints(request);
                infraction.Category = request.Category;
                infraction.Body = request.Body;

                if (request.LiftBan)
                    infraction.BanLiftDate = DateTime.Now;

                _dbContext.Entry(infraction).State = EntityState.Modified;

                try
                {
                    await _dbContext.SaveChangesAsync(CancellationToken.None);
                    var infractionToReturn = await _dbContext.Infractions
                        .Include(infraction => infraction.User)
                        .Include(infraction => infraction.Moderator)
                        .Where(infraction => infraction.Id == request.Id)
                        .FirstOrDefaultAsync();
                    return new PutInfractionResponse { Data = _mapper.Map<InfractionDto>(infractionToReturn), ResponseStatus = ResponseStatus.Ok, ResponseMessage = "Infraction updated" };
                }
                catch (DbUpdateConcurrencyException)
                {
                    return new PutInfractionResponse { ResponseStatus = ResponseStatus.Error, ResponseMessage = "Something went wrong, please try again" };
                }
            }
            else
            {
                return new PutInfractionResponse { ResponseStatus = ResponseStatus.NotAuthorized, ResponseMessage = "Not authorized to edit infractions" };
            }
        }

        private int? DeterminePoints(PutInfractionRequest request)
        {
            if (request.Points != null)
                return request.Points;

            return request.Category switch
            {
                InfractionCategory.Spam => 1,
                InfractionCategory.Inappropriate => 1,
                InfractionCategory.Harassment => 2,
                InfractionCategory.Other => request.Points,
                _ => null,
            };
        }
    }
}
