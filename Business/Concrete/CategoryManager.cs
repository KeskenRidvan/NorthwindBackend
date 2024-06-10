using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;
public class CategoryManager : ICategoryService
{
	private readonly ICategoryDal _categoryDal;

	public CategoryManager(ICategoryDal categoryDal)
	{
		_categoryDal = categoryDal;
	}

	[TransactionScopeAspect]
	[CacheRemoveAspect(pattern: "ICategoryService.Get")]
	public IResult Add(Category category)
	{
		_categoryDal.Add(category);
		return new SuccessResult(message: Messages.CategoryAdded);
	}

	[TransactionScopeAspect]
	[CacheRemoveAspect(pattern: "ICategoryService.Get")]
	public IResult Delete(Category category)
	{
		_categoryDal.Delete(category);
		return new SuccessResult(message: Messages.CategoryDeleted);
	}

	public IDataResult<Category> GetById(int categoryId)
	{
		return new SuccessDataResult<Category>(
		data: _categoryDal.Get(
			filter: p => p.CategoryId.Equals(categoryId)));
	}

	[SecuredOperation("Product.List,Admin")]
	[CacheAspect(duration: 5)]
	public IDataResult<List<Category>> GetList()
	{
		return new SuccessDataResult<List<Category>>(
		data: _categoryDal.GetList().ToList());
	}

	[TransactionScopeAspect]
	[CacheRemoveAspect(pattern: "ICategoryService.Get")]
	public IResult Update(Category category)
	{
		_categoryDal.Update(category);
		return new SuccessResult(message: Messages.CategoryUpdated);
	}
}
