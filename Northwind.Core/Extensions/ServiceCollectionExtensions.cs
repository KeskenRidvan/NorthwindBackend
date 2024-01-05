using Microsoft.Extensions.DependencyInjection;
using Northwind.Core.Utilities.IoC.Abstract;
using Northwind.Core.Utilities.IoC.Concrete;

namespace Northwind.Core.Extensions;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddDependencyResolvers(this IServiceCollection services, ICoreModule[] modules)
	{
		foreach (var module in modules)
			module.Load(services);

		return ServiceTool.Create(services);
	}
}
