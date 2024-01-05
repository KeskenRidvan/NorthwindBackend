using Microsoft.Extensions.DependencyInjection;
using Northwind.Core.CrossCuttingConcerns.Caching.Abstract;
using Northwind.Core.CrossCuttingConcerns.Caching.Concrete.Microsoft;
using Northwind.Core.Utilities.IoC.Abstract;

namespace Northwind.Core.DependencyResolvers;

public class CoreModule : ICoreModule
{
	public void Load(IServiceCollection services)
	{
		services.AddMemoryCache();
		services.AddSingleton<ICacheManager, MemoryCacheManager>();
	}
}
