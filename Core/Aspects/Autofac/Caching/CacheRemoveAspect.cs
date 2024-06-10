using Castle.DynamicProxy;
using Core.CrosCuttingConcerns.Caching;
using Core.IoC;
using Core.Utilities.Interceptors;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Caching;
public class CacheRemoveAspect : MethodInterception
{
	private string _pattern;
	private ICacheManager _cacheManager;

	public CacheRemoveAspect(string pattern)
	{
		_pattern = pattern;
		_cacheManager =
			ServiceTool.ServiceProvider.GetService<ICacheManager>();
	}
	protected override void OnSuccess(IInvocation ınvocation) =>
		_cacheManager.RemoveByPattern(_pattern);
}