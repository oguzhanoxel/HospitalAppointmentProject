using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Persistence.Repositories;

public interface IRepository<TEntity, TId>
	where TEntity : Entity<TId>, new()
{
	TEntity? Get(
		Expression<Func<TEntity, bool>> predicate,
		Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);
	List<TEntity> GetAll(
		Expression<Func<TEntity, bool>>? predicate = null,
		Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);
	TEntity Create(TEntity item);
	TEntity Update(TEntity item);
	TEntity Delete(TEntity item);
}
