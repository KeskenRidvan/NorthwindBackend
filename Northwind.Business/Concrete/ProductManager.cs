using Northwind.Business.Abstract;
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

	public IResult Add(Product product)
	{
		_productDal.Add(product);
		return new SuccessResult("Ürün başarıyla eklendi.");
	}

	public IResult Update(Product product)
	{
		_productDal.Update(product);
		return new SuccessResult("Ürün başarıyla güncellendi.");
	}

	public IResult Delete(Product product)
	{
		_productDal.Delete(product);
		return new SuccessResult("Ürün başarıyla silindi.");
	}

	public IDataResult<List<Product>> GetAll()
	{
		return new SuccessDataResult<List<Product>>(_productDal.GetList().ToList());
	}

	public IDataResult<Product> GetById(int productId)
	{
		return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId.Equals(productId)));
	}

	public IDataResult<List<Product>> GetListByCategory(int categoryId)
	{
		return new SuccessDataResult<List<Product>>(_productDal.GetList(c => c.CategoryId.Equals(categoryId)).ToList());
	}
}