using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Core.CrossCuttingConcerns.Caching.Abstract;
using Northwind.Core.Utilities.Interceptors.Autofac.Concrete;
using Northwind.Core.Utilities.IoC.Concrete;

namespace Northwind.Core.Aspect.Autofac.Caching;

public class CacheRemoveAspect : MethodInterception
{
	private string _pattern;
	private ICacheManager _cacheManager;

	public CacheRemoveAspect(string pattern)
	{
		_pattern = pattern;
		_cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
	}
	protected override void OnSuccess(IInvocation ınvocation) => _cacheManager.RemoveByPattern(_pattern);
}
