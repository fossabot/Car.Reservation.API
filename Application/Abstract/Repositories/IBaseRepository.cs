using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Domain.Models;

namespace Application.Abstract.Repositories
{
    public interface IBaseRepository<TModel> where TModel : BaseEntity
    {
      
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
