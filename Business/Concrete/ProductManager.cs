﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
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

	[TransactionScopeAspect]
	[ValidationAspect(typeof(ProductValidator), Priority = 1)]
	[CacheRemoveAspect(pattern: "IProductService.Get")]
	public IResult Add(Product product)
	{
		_productDal.Add(product);
		return new SuccessResult(message: Messages.ProductAdded);
	}

	[TransactionScopeAspect]
	[CacheRemoveAspect(pattern: "IProductService.Get")]
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

	[CacheAspect(duration: 1)]
	public IDataResult<List<Product>> GetList()
	{
		return new SuccessDataResult<List<Product>>(
			data: _productDal.GetList().ToList());
	}

	[CacheAspect(duration: 1)]
	public IDataResult<List<Product>> GetListByCategory(int categoryId)
	{
		return new SuccessDataResult<List<Product>>(
			data: _productDal.GetList(
				filter: p => p.CategoryId.Equals(categoryId)).ToList());
	}

	[TransactionScopeAspect]
	[CacheRemoveAspect(pattern: "IProductService.Get")]
	public IResult Update(Product product)
	{
		_productDal.Update(product);
		return new SuccessResult(message: Messages.ProductUpdated);
	}
}