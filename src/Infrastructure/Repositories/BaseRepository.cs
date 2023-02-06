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

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
