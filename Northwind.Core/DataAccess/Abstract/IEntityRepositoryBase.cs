using Northwind.Core.Entities.Abstract;
using System.Linq.Expressions;

namespace Northwind.Core.DataAccess.Abstract;

public interface IEntityRepositoryBase<TEntity> where TEntity : class, IEntity, new()
{
	TEntity Get(Expression<Func<TEntity, bool>> filter);
	IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null);
	void Add(TEntity entity);
	void Update(TEntity entity);
	void Delete(TEntity entity);
}
