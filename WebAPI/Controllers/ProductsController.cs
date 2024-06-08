using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
	private readonly IProductService _productService;

	public ProductsController(IProductService productService)
	{
		_productService = productService;
	}

	[HttpGet]
	public IActionResult GetList()
	{
		var result = _productService.GetList();

		if (!result.Success)
			return BadRequest(result.Message);

		return Ok(result.Data);
	}

	[HttpGet("{productId}")]
	public IActionResult Get([FromRoute] int productId)
	{
		var result = _productService.GetById(productId);

		if (!result.Success)
			return BadRequest(result.Message);

		return Ok(result.Data);
	}

	[HttpGet("getbycategory/{categoryId}")]
	public IActionResult GetByCategory([FromRoute] int categoryId)
	{
		var result = _productService.GetListByCategory(categoryId);

		if (!result.Success)
			return BadRequest(result.Message);

		return Ok(result.Data);
	}

	[HttpPost]
	public IActionResult Add([FromBody] Product product)
	{
		var result = _productService.Add(product);

		if (!result.Success)
			return BadRequest(result.Message);

		return Ok(result.Message);
	}

	[HttpPut]
	public IActionResult Update([FromBody] Product product)
	{
		var result = _productService.Update(product);

		if (!result.Success)
			return BadRequest(result.Message);

		return Ok(result.Message);
	}

	[HttpDelete]
	public IActionResult Delete([FromBody] Product product)
	{
		var result = _productService.Delete(product);

		if (!result.Success)
			return BadRequest(result.Message);

		return Ok(result.Message);
	}
}