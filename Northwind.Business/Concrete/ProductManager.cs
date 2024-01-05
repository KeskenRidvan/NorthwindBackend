using Northwind.Business.Abstract;
using Northwind.Business.Constants;
using Northwind.Business.ValidationRules.FluentValidation;
using Northwind.Core.Aspect.Autofac.Caching;
using Northwind.Core.Aspect.Autofac.Validation;
using Northwind.Core.Utilities.Results.Abstract;
using Northwind.Core.Utilities.Results.Concrete;
using Northwind.DataAccess.Abstract;
using Northwind.Entities.Concrete;

namespace Northwind.Business.Concrete;

public class ProductManager : IProductService
{
	private readonly IProductDal _productDal;

	public ProductManager(IProductDal productDal)
	{
		_productDal = productDal;
	}

	[ValidationAspect(typeof(ProductValidator))]
	[CacheRemoveAspect("IProductService.Get")]
	public IResult Add(Product product)
	{
		_productDal.Add(product);
		return new SuccessResult(Messages.ProductAdded);
	}

	public IResult Update(Product product)
	{
		_productDal.Update(product);
		return new SuccessResult(Messages.ProductUpdated);
	}

	public IResult Delete(Product product)
	{
		_productDal.Delete(product);
		return new SuccessResult(Messages.ProductDeleted);
	}

	public IDataResult<List<Product>> GetAll()
	{
		return new SuccessDataResult<List<Product>>(_productDal.GetList().ToList(), Messages.ProductsListed);
	}

	public IDataResult<Product> GetById(int productId)
	{
		return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId.Equals(productId)), Messages.ProductListed);
	}

	[CacheAspect(duration: 1)]
	public IDataResult<List<Product>> GetListByCategory(int categoryId)
	{
		return new SuccessDataResult<List<Product>>(_productDal.GetList(c => c.CategoryId.Equals(categoryId)).ToList(), Messages.ProductsListedByCategory);
	}
}