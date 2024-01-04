using Northwind.Core.Entities.Concrete;
using Northwind.Core.Utilities.Security.JWT.Abstract;

namespace Northwind.Core.Utilities.Security.JWT.Concrete;

public class JwtHelper : ITokenHelper
{
	public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
	{
		throw new NotImplementedException();
	}
}
