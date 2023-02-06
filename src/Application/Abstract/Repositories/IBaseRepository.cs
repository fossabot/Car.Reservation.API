using Domain.Models;
using System.Linq.Expressions;

namespace Application.Abstract.Repositories
{
    public interface IBaseRepository<TModel> where TModel : BaseEntity
    {

        TModel Add(TModel entity);
        TModel Update(TModel entity);
        TModel Delete(TModel entity);

        Task<TModel> FindByIdAsync(long id, CancellationToken cancellationToken);

        Task<IList<TModel>> ListAsync(CancellationToken cancellationToken = default);
        Task<IList<TModel>> ListAsync(Expression<Func<TModel, bool>> predicate, CancellationToken cancellationToken = default);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
