using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Smash_Combos.Core.Services;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Smash_Combos.Core.Cqrs.Combos.DeleteCombo
{
    public class DeleteComboRequestHandler : IRequestHandler<DeleteComboRequest, DeleteComboResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _dbContext;

        public DeleteComboRequestHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<DeleteComboResponse> Handle(DeleteComboRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _dbContext.Users.Where(user => user.Id == request.CurrentUserId).SingleOrDefaultAsync();

            if (currentUser == null)
                throw new KeyNotFoundException($"User with id {request.CurrentUserId} does not exist");

            var combo = await _dbContext.Combos.Where(combo => combo.Id == request.ComboId).FirstOrDefaultAsync();
            if (combo == null)
                throw new KeyNotFoundException($"Combo with id {request.ComboId} does not exist");

            if (combo.User.Id == currentUser.Id || currentUser.UserType == UserType.Moderator || currentUser.UserType == UserType.Admin)
            {
                _dbContext.Combos.Remove(combo);
                await _dbContext.SaveChangesAsync(CancellationToken.None);

                return new DeleteComboResponse();
            }
            else
            {
                throw new SecurityException("Not authorized to delete this combo");
            }
        }
    }
}
