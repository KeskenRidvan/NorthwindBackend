using Northwind.Entities.Concrete;

namespace Northwind.Business.Abstract;

public interface IProductService
{
	Product GetById(int productId);
	List<Product> GetAll();
	List<Product> GetListByCategory(int categoryId);
	void Add(Product product);
	void Update(Product product);
	void Delete(Product product);
}
