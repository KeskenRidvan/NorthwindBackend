using Core.CrosCuttingConcerns.Caching;
using Core.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DependencyResolvers;
public class CoreModule : ICoreModule
{
	public void Load(IServiceCollection services)
	{
		services.AddMemoryCache();
		services.AddSingleton<ICacheManager, MemoryCacheManager>();
	}
}