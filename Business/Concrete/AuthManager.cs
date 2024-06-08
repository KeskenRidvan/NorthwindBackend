using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;

namespace Business.Concrete;
public class AuthManager : IAuthService
{
	private readonly IUserService _userService;
	private readonly ITokenHelper _tokenHelper;

	public AuthManager(
		IUserService userService,
		ITokenHelper tokenHelper)
	{
		_userService = userService;
		_tokenHelper = tokenHelper;
	}

	public IDataResult<AccessToken> CreateAccessToken(User user)
	{
		var claims =
			_userService.GetClaims(user);

		var accessToken =
			_tokenHelper.CreateToken(user, claims);

		return new SuccessDataResult<AccessToken>(
			accessToken,
			Messages.AccessTokenCreated);
	}

	public IDataResult<User> Login(UserForLoginDto userForLoginDto)
	{
		var userCheck =
			_userService.GetByMail(userForLoginDto.Email);

		if (userCheck is null)
			return new ErrorDataResult<User>(Messages.UserOrPasswordError);

		if (!HashingHelper.VerifyPasswordHash(
			userForLoginDto.Password,
			userCheck.PasswordHash,
			userCheck.PasswordSalt))
			return new ErrorDataResult<User>(Messages.UserOrPasswordError);

		return new SuccessDataResult<User>(
			userCheck,
			Messages.SuccessfullLogin);
	}

	public IDataResult<User> Register(
		UserForRegisterDto userForRegisterDto,
		string password)
	{
		byte[] passwordHash, passwordSalt;

		HashingHelper.CreatePasswordHash(
			password,
			out passwordHash,
			out passwordSalt);

		var user = new User
		{
			Email = userForRegisterDto.Email,
			FirstName = userForRegisterDto.FirstName,
			LastName = userForRegisterDto.LastName,
			PasswordSalt = passwordSalt,
			PasswordHash = passwordHash,
			Status = true
		};
		_userService.Add(user);

		return new SuccessDataResult<User>(
			user,
			Messages.UserRegistered);
	}

	public IResult UserExists(string email)
	{
		if (_userService.GetByMail(email) is not null)
			return new ErrorResult(Messages.UserAlreadyExists);

		return new SuccessResult();
	}
}