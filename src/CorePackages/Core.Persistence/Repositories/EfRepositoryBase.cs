using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.Persistence.Repositories;

public class EfRepositoryBase<TContext, TEntity> : IRepository<TEntity, int>
where TEntity : Entity<int>, new()
where TContext : DbContext
{
	protected TContext _context { get; }

	public EfRepositoryBase(TContext context)
	{
		_context = context;
	}

	public TEntity? Get(
		Expression<Func<TEntity, bool>> predicate,
		Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
	{
		IQueryable<TEntity> query = _context.Set<TEntity>();
		if (include != null) query = include(query);
		return query.SingleOrDefault(predicate);
	}

	public List<TEntity> GetAll(
		Expression<Func<TEntity, bool>>? predicate = null,
		Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
	{
		IQueryable<TEntity> query = _context.Set<TEntity>();

		if (include != null) query = include(query);
		if (predicate != null) query = query.Where(predicate);

		return query.ToList();
	}

	public TEntity Create(TEntity item)
	{
		_context.Set<TEntity>().Add(item);
		_context.SaveChanges();
		return item;
	}

	public TEntity Delete(TEntity item)
	{
		_context.Set<TEntity>().Remove(item);
		_context.SaveChanges();
		return item;
	}

	public TEntity Update(TEntity item)
	{
		_context.Set<TEntity>().Update(item);
		_context.SaveChanges();
		return item;
	}
}
