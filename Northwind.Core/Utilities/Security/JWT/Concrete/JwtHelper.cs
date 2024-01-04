using Microsoft.Extensions.Configuration;
using Northwind.Core.Entities.Concrete;
using Northwind.Core.Utilities.Security.Encyption;
using Northwind.Core.Utilities.Security.JWT.Abstract;

namespace Northwind.Core.Utilities.Security.JWT.Concrete;

public class JwtHelper : ITokenHelper
{
	public IConfiguration Configuration { get; }
	private readonly TokenOptions _tokenOptions;

	public JwtHelper(IConfiguration configuration)
	{
		Configuration = configuration;
		_tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>(); // Paketlerden Microsoft.Extensions.Configuration.Binder kurulması gerekiyor.
	}

	public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
	{

		var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
	}
}
