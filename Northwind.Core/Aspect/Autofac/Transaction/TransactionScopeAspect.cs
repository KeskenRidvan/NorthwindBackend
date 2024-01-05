using Castle.DynamicProxy;
using Northwind.Core.Utilities.Interceptors.Autofac.Concrete;
using System.Transactions;

namespace Northwind.Core.Aspect.Autofac.Transaction;

public class TransactionScopeAspect : MethodInterception
{
	public override void Intercept(IInvocation invocation)
	{
		using (TransactionScope transactionScope = new())
		{
			try
			{
				invocation.Proceed();
				transactionScope.Complete();
			}
			catch (Exception ex)
			{
				transactionScope.Dispose();
				throw;
			}
		}
	}
}
