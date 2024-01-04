using Northwind.Business.Abstract;
using Northwind.Business.Constants;
using Northwind.Core.Utilities.Results.Abstract;
using Northwind.Core.Utilities.Results.Concrete;
using Northwind.DataAccess.Abstract;
using Northwind.Entities.Concrete;

namespace Northwind.Business.Concrete;

public class CategoryManager : ICategoryService
{

	private readonly ICategoryDal _categoryDal;

	public CategoryManager(ICategoryDal categoryDal)
	{
		_categoryDal = categoryDal;
	}

	public IResult Add(Category category)
	{
		_categoryDal.Add(category);
		return new SuccessResult(Messages.CategoryAdded);
	}

	public IResult Delete(Category category)
	{
		_categoryDal.Delete(category);
		return new SuccessResult(Messages.CategoryDeleted);
	}

	public IDataResult<List<Category>> GetAll()
	{
		return new SuccessDataResult<List<Category>>(_categoryDal.GetList().ToList(), Messages.CategoriesListed);
	}

	public IDataResult<Category> GetById(int categoryId)
	{
		return new SuccessDataResult<Category>(_categoryDal.Get(p => p.CategoryId.Equals(categoryId)), Messages.CategoryListed);
	}

	public IResult Update(Category category)
	{
		_categoryDal.Update(category);
		return new SuccessResult(Messages.CategoryUpdated);
	}
}
