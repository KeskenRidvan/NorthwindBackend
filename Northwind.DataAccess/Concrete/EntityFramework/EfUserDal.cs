using Northwind.Core.DataAccess.Concrete.EntityFramework;
using Northwind.Core.Entities.Concrete;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete.EntityFramework.Context;

namespace Northwind.DataAccess.Concrete.EntityFramework;

public class EfUserDal : EfEntityRepositoryBase<User, AppDbContext>, IUserDal
{
	public List<OperationClaim> GetClaims(User user)
	{
		using (var context = new AppDbContext())
		{
			var result = from operationClaim in context.OperationClaims
									 join userOperationClaim in context.UserOperationClaims
									 on operationClaim.Id equals userOperationClaim.OperationClaimId
									 where userOperationClaim.UserId.Equals(user.Id)
									 select new OperationClaim
									 {
										 Id = operationClaim.Id,
										 Name = operationClaim.Name
									 };

			return result.ToList();
		}
	}
}
