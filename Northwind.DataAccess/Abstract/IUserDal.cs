using Northwind.Core.DataAccess.Abstract;
using Northwind.Core.Entities.Concrete;

namespace Northwind.DataAccess.Abstract;

public interface IUserDal : IEntityRepositoryBase<User>
{
	List<OperationClaim> GetClaims(User user);
}
