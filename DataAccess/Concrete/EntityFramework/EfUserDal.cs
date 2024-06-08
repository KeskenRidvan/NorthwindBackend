using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;

namespace DataAccess.Concrete.EntityFramework;
public class EfUserDal : EfEntityRepositoryBase<User, NorhwindContext>, IUserDal
{
	public List<OperationClaim> GetClaims(User user)
	{
		using (var context = new NorhwindContext())
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
