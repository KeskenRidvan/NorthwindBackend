using Northwind.Core.Entities.Concrete;
using Northwind.Core.Utilities.Security.JWT.Concrete;

namespace Northwind.Core.Utilities.Security.JWT.Abstract;

public interface ITokenHelper
{
	AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
}
