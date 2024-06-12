using Castle.DynamicProxy;
using Core.CrosCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using Core.Utilities.Messages;
using FluentValidation;

namespace Core.Aspects.Autofac.Validation;
public class ValidationAspect : MethodInterception
{
	private Type _validatorType;
	public ValidationAspect(Type validatorType)
	{
		if (!typeof(IValidator).IsAssignableFrom(validatorType))
			throw new System.Exception(AspectMessages.WrongValidationType);

		_validatorType = validatorType;
	}
	protected override void OnBefore(IInvocation invocation)
	{
		var validator =
			(IValidator)Activator.CreateInstance(_validatorType);

		var entityType =
			_validatorType.BaseType.GetGenericArguments()[0];

		var entities = invocation.Arguments
			.Where(t => t.GetType().Equals(entityType));

		foreach (var item in entities)
			ValidationTool.Validate(validator, item);
	}
}