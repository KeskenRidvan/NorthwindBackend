using Northwind.Core.Entities.Concrete;
using Northwind.Core.Utilities.Results.Abstract;
using Northwind.Core.Utilities.Security.JWT.Concrete;
using Northwind.Entities.DTOs;

namespace Northwind.Business.Abstract;

public interface IAuthService
{
	IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
	IDataResult<User> Login(UserForLoginDto userForLoginDto);
	IResult UserExists(string email);
	IDataResult<AccessToken> CreateAccessToken(User user);
}
