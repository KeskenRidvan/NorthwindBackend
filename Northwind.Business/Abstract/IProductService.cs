using Northwind.Core.Utilities.Results.Abstract;
using Northwind.Entities.Concrete;

namespace Northwind.Business.Abstract;

public interface IProductService
{
	IDataResult<Product> GetById(int productId);
	IDataResult<List<Product>> GetAll();
	IDataResult<List<Product>> GetListByCategory(int categoryId);
	IResult Add(Product product);
	IResult Update(Product product);
	IResult Delete(Product product);
}
