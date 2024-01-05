using Microsoft.Extensions.DependencyInjection;
using Northwind.Core.Utilities.IoC.Abstract;

namespace Northwind.Core.DependencyResolvers;

public class CoreModule : ICoreModule
{
	public void Load(IServiceCollection services)
	{
		services.AddMemoryCache();
	}
}
