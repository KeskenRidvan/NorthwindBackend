﻿namespace Core.Utilities.Results;
public class DataResult<TEntity> : Result, IDataResult<TEntity>
{
	public DataResult(
		TEntity data,
		bool success) : base(success)
	{
		Data = data;
	}

	public DataResult(
		TEntity data,
		bool success,
		string message) : base(success, message)
	{
		Data = data;
	}

	public TEntity Data { get; }
}