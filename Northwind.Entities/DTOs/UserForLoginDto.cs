using Northwind.Core.Entities.Abstract;

namespace Northwind.Entities.DTOs;

public class UserForLoginDto : IDto
{
	public string Email { get; set; }
	public string Password { get; set; }
}
