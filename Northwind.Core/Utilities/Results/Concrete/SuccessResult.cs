namespace Northwind.Core.Utilities.Results.Concrete;

public class SuccessResult : Result
{
	public SuccessResult(bool success) : base(true) { }

	public SuccessResult(bool success, string message) : base(true, message) { }
}
