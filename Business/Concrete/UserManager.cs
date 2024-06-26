﻿using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;

namespace Business.Concrete;
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
		return _userDal.Get(
			filter: u => u.Email.Equals(email));
	}

	public List<OperationClaim> GetClaims(User user)
	{
		return _userDal.GetClaims(user);
	}
}