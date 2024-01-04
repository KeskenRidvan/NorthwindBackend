using Northwind.Business.Abstract;
using Northwind.Core.Entities.Concrete;
using Northwind.DataAccess.Abstract;

namespace Northwind.Business.Concrete;

public class UserManager : IUserService
{
	private readonly IUserDal _userDal;
	public UserManager(IUserDal userDal)
	{
		_userDal = userDal;
	}

	public void Add(User user)
	{
		_userDal.Add(user);
	}

	public User GetByMail(string email)
	{
		return _userDal.Get(u => u.Email.Equals(email));
	}

	public List<OperationClaim> GetClaims(User user)
	{
		return _userDal.GetClaims(user);
	}
}
