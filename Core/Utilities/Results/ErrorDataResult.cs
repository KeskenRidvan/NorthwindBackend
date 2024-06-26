﻿namespace Core.Utilities.Results;
public class ErrorDataResult<TEntity> : DataResult<TEntity>
{
	public ErrorDataResult(TEntity data) : base(data, false)
	{
	}

	public ErrorDataResult(TEntity data, string message) : base(data, false, message)
	{
	}

	public ErrorDataResult(string message) : base(default, false, message)
	{
	}
	public ErrorDataResult() : base(default, false)
	{
	}
}