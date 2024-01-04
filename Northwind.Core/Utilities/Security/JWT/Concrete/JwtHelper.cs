using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Northwind.Core.Entities.Concrete;
using Northwind.Core.Extensions;
using Northwind.Core.Utilities.Security.Encyption;
using Northwind.Core.Utilities.Security.JWT.Abstract;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Northwind.Core.Utilities.Security.JWT.Concrete;

public class JwtHelper : ITokenHelper
{
	public IConfiguration Configuration { get; }
	private readonly TokenOptions _tokenOptions;
	private DateTime _accessTokenExpiration;

	public JwtHelper(IConfiguration configuration)
	{
		Configuration = configuration;
		_tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>(); // Paketlerden Microsoft.Extensions.Configuration.Binder kurulması gerekiyor.
	}

	public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
	{
		_accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);

		var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
		var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
	}

	public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
	{
		JwtSecurityToken jwt = new(
						 issuer: tokenOptions.Issuer,
						 audience: tokenOptions.Audience,
						 expires: _accessTokenExpiration,
						 notBefore: DateTime.Now,
						 claims: SetClaims(user, operationClaims),
						 signingCredentials: signingCredentials);

		return jwt;
	}

	private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
	{
		var claims = new List<Claim>();
		claims.AddNameIdentifier(user.Id.ToString());
		claims.AddEmail(user.Email);
		claims.AddName($"{user.FirstName} {user.LastName}");
		claims.AddRoles(operationClaims.Select(r => r.Name).ToArray());

		return claims;
	}

}