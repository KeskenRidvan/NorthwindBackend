using Northwind.Core.Utilities.Results.Abstract;
using Northwind.Entities.Concrete;

namespace Northwind.Business.Abstract;

public interface ICategoryService
{
	IDataResult<Category> GetById(int categoryId);
	IDataResult<List<Category>> GetAll();
	IResult Add(Category category);
	IResult Update(Category category);
	IResult Delete(Category category);
}
