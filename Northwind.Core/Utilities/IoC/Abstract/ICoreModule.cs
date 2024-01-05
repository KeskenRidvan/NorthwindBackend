using Microsoft.Extensions.DependencyInjection;

namespace Northwind.Core.Utilities.IoC.Abstract;

public interface ICoreModule
{
	void Load(IServiceCollection collection);
}
