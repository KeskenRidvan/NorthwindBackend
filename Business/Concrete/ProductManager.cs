using Business.Abstract;
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

	public void Add(Product product)
	{
		_productDal.Add(product);
	}

	public void Delete(Product product)
	{
		_productDal.Delete(product);
	}

	public Product GetById(int productId)
	{
		return _productDal.Get(
			filter: p => p.ProductId.Equals(productId));
	}

	public List<Product> GetList()
	{
		return _productDal.GetList().ToList();
	}

	public List<Product> GetListByCategory(int categoryId)
	{
		return _productDal.GetList(
			filter: p => p.CategoryId.Equals(categoryId)).ToList();
	}

	public void Update(Product product)
	{
		_productDal.Update(product);
	}
}