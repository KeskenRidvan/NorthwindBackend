using System.Security.Cryptography;
using System.Text;

namespace Core.Utilities.Security.Hashing;
public class HashingHelper
{
	public static void CreatePasswordHash(
		string password,
		out byte[] passworHash,
		out byte[] passwordSalt)
	{
		using (var hmac = new HMACSHA512())
		{
			passwordSalt = hmac.Key;
			passworHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
		}
	}

	public static bool VerifyPasswordHash(
		string password,
		byte[] passworHash,
		byte[] passwordSalt)
	{
		using (var hmac = new HMACSHA512(passwordSalt))
		{
			var computedHash =
				hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

			for (var i = 0; i < computedHash.Length; i++)
			{
				if (!computedHash[i].Equals(passworHash[i]))
					return false;
			}
		}
		return true;
	}
}