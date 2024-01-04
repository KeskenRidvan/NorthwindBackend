using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Northwind.Business.Abstract;
using Northwind.Entities.Concrete;

namespace Northwind.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
	private readonly IProductService _productService;

	public ProductsController(IProductService productService)
	{
		_productService = productService;
	}

	[HttpGet("getall")]
	public IActionResult GetList()
	{
		var result = _productService.GetAll();
		if (result.Success)
			return Ok(result.Data);

		return BadRequest(result.Message);
	}

	[HttpGet("getlistbycategory")]
	public IActionResult GetListByCategory(int categoryId)
	{
		var result = _productService.GetListByCategory(categoryId);
		if (result.Success)
			return Ok(result.Data);

		return BadRequest(result.Message);
	}

	[HttpGet("getbyid")]
	public IActionResult GetById(int productId)
	{
		var result = _productService.GetById(productId);
		if (result.Success)
			return Ok(result.Data);

		return BadRequest(result.Message);
	}

	[HttpPost("add")]
	[Authorize(Roles = "Product.Add")]
	public IActionResult Add(Product product)
	{
		var result = _productService.Add(product);
		if (result.Success)
			return Ok(result.Message);

		return BadRequest(result.Message);
	}

	[HttpPut("update")]
	public IActionResult Update(Product product)
	{
		var result = _productService.Update(product);
		if (result.Success)
			return Ok(result.Message);

		return BadRequest(result.Message);
	}

	[HttpDelete("delete")]
	public IActionResult Delete(Product product)
	{
		var result = _productService.Delete(product);
		if (result.Success)
			return Ok(result.Message);

		return BadRequest(result.Message);
	}
}
