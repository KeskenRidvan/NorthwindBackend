using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[Route("api/categories")]
[ApiController]
public class CategoriesController : ControllerBase
{
	private readonly ICategoryService _categoryService;

	public CategoriesController(ICategoryService categoryService)
	{
		_categoryService = categoryService;
	}

	[HttpGet]
	public IActionResult GetList()
	{
		var result = _categoryService.GetList();

		if (!result.Success)
			return BadRequest(result.Message);

		return Ok(result.Data);
	}

	[HttpGet("{categoryId}")]
	public IActionResult Get([FromRoute] int categoryId)
	{
		var result = _categoryService.GetById(categoryId);

		if (!result.Success)
			return BadRequest(result.Message);

		return Ok(result.Data);
	}

	[HttpPost]
	public IActionResult Add([FromBody] Category category)
	{
		var result = _categoryService.Add(category);

		if (!result.Success)
			return BadRequest(result.Message);

		return Ok(result.Message);
	}

	[HttpPut]
	public IActionResult Update([FromBody] Category category)
	{
		var result = _categoryService.Update(category);

		if (!result.Success)
			return BadRequest(result.Message);

		return Ok(result.Message);
	}

	[HttpDelete]
	public IActionResult Delete([FromBody] Category category)
	{
		var result = _categoryService.Delete(category);

		if (!result.Success)
			return BadRequest(result.Message);

		return Ok(result.Message);
	}
}