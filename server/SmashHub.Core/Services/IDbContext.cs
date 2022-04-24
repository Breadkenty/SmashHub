using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SmashHub.Domain.Models;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace SmashHub.Core.Services
{
    public interface IDbContext
    {
        public DatabaseFacade Database { get; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Combo> Combos { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ComboVote> ComboVotes { get; set; }
        public DbSet<CommentVote> CommentVotes { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Infraction> Infractions { get; set; }
        public EntityEntry Entry([NotNullAttribute] object entity);
        public EntityEntry<TEntity> Entry<TEntity>([NotNullAttribute] TEntity entity) where TEntity : class;
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
