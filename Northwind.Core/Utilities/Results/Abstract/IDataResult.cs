namespace Northwind.Core.Utilities.Results.Abstract;

public interface IDataResult<TEntity> : IResult
{
	TEntity Data { get; }
}
