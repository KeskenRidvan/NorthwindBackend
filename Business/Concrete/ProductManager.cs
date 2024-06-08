using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;
public class ProductManager : IProductService
{
	private readonly IProductDal _productDal;

	public ProductManager(IProductDal productDal)
	{
		_productDal = productDal;
	}

	public IResult Add(Product product)
	{
		_productDal.Add(product);
		return new SuccessResult(message: Messages.ProductAdded);
	}

	public IResult Delete(Product product)
	{
		_productDal.Delete(product);
		return new SuccessResult(message: Messages.ProductDeleted);
	}

	public IDataResult<Product> GetById(int productId)
	{
		return new SuccessDataResult<Product>(
		data: _productDal.Get(
			filter: p => p.ProductId.Equals(productId)));
	}

	public IDataResult<List<Product>> GetList()
	{
		return new SuccessDataResult<List<Product>>(
		data: _productDal.GetList().ToList());
	}

	public IDataResult<List<Product>> GetListByCategory(int categoryId)
	{
		return new SuccessDataResult<List<Product>>(
		data: _productDal.GetList(
				filter: p => p.CategoryId.Equals(categoryId)).ToList());
	}

	public IResult Update(Product product)
	{
		_productDal.Update(product);
		return new SuccessResult(message: Messages.ProductUpdated);
	}
}