using System.Linq.Expressions;
using Application.Abstract.Repositories;
using Domain.Models;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public abstract class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : BaseEntity
    {
        protected readonly CarReservationContext Context;
        protected readonly DbSet<TModel> Set;

        public BaseRepository(CarReservationContext context)
        {
            Context = context;
            Set = Context.Set<TModel>();
        }

        public TModel Add(TModel entity)
        {
            return Set.Add(entity)?.Entity;
        }

        public TModel Update(TModel entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return Set.Update(entity).Entity;
        }

        public TModel Delete(TModel entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return Set.Remove(entity).Entity;
        }

        public async Task<TModel> FindByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            var result = await Set.FindAsync(new object[] { id }, cancellationToken);
            return result;
        }

        public async Task<IList<TModel>> ListAsync(CancellationToken cancellationToken = default)
        {
            return await Set.ToListAsync(cancellationToken);
        }

        public async Task<IList<TModel>> ListAsync(Expression<Func<TModel, bool>> predicate, CancellationToken cancellationToken = default)
        {
            var result = await Set.Where(predicate).ToListAsync(cancellationToken);
            return result;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await Context.SaveChangesAsync(cancellationToken);
        }
    }
}
