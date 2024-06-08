using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[Route("api/auths")]
[ApiController]
public class AuthsController : ControllerBase
{
	private IAuthService _authService;

	public AuthsController(IAuthService authService)
	{
		_authService = authService;
	}

	[HttpPost("login")]
	public IActionResult Login([FromBody] UserForLoginDto userForLoginDto)
	{
		var userToLogin =
			_authService.Login(userForLoginDto);

		if (!userToLogin.Success)
			return BadRequest(userToLogin.Message);

		var result =
			_authService.CreateAccessToken(userToLogin.Data);

		if (result.Success)
			return Ok(result.Data);

		return BadRequest(result.Message);
	}

	[HttpPost("register")]
	public IActionResult Register([FromBody] UserForRegisterDto userForRegisterDto)
	{
		var userExists = _authService.UserExists(userForRegisterDto.Email);

		if (!userExists.Success)
			return BadRequest(userExists.Message);

		var registerResult = _authService.Register(
			userForRegisterDto,
			userForRegisterDto.Password);

		var result =
			_authService.CreateAccessToken(registerResult.Data);

		if (result.Success)
			return Ok(result.Message);

		return BadRequest(result.Message);
	}
}