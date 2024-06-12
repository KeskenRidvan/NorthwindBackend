using Castle.DynamicProxy;
using Core.Aspects.Autofac.Exception;
using Core.CrosCuttingConcerns.Logging.Log4Net.Loggers;
using System.Reflection;

namespace Core.Utilities.Interceptors;
public class AspectInterceptorSelector : IInterceptorSelector
{
	public IInterceptor[] SelectInterceptors(
		Type type,
		MethodInfo method,
		IInterceptor[] interceptors)
	{
		var classAttributes = type
			.GetCustomAttributes<MethodInterceptionBaseAttribute>(inherit: true)
			.ToList();

		var methodAttributes = type
			.GetMethod(method.Name)
			.GetCustomAttributes<MethodInterceptionBaseAttribute>(inherit: true);

		classAttributes.AddRange(methodAttributes);
		classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));
		//classAttributes.Add(new ExceptionLogAspect(typeof(DatabaseLogger)));

		return classAttributes.OrderBy(x => x.Priority).ToArray();
	}
}