using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;
public class ProductValidator : AbstractValidator<Product>
{
	public ProductValidator()
	{
		RuleFor(p => p.ProductName)
		.NotEmpty()
		.Length(2, 30);

		RuleFor(p => p.UnitPrice)
		.NotEmpty()
		.GreaterThanOrEqualTo(1)
		.GreaterThanOrEqualTo(10).When(p => p.CategoryId.Equals(1));
	}
}