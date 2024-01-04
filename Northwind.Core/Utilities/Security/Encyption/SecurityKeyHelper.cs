using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Northwind.Core.Utilities.Security.Encyption;

public class SecurityKeyHelper
{
	public static SecurityKey CreateSecurityKey(string securityKey)
	{
		return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
	}
}
