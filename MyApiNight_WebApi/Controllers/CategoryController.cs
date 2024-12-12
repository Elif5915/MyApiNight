using Microsoft.AspNetCore.Mvc;
using MyApiNight_BusinessLayer.Abstract;
using MyApiNight_EntityLayer.Concrete;

namespace MyApiNight_WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
	private readonly ICategoryService _categoryService;

	public CategoryController(ICategoryService categoryService)
	{
		_categoryService = categoryService;
	}

	[HttpGet]
	public IActionResult CategoryList()
	{
		var values = _categoryService.TGetAll();
		return Ok(values);
	}

	[HttpPost]
	public IActionResult CreateCategory(Category category)
	{
		_categoryService.TInsert(category);
		return Ok("Ekleme Başarılı");

	}

	[HttpDelete]
	public IActionResult PutCategory(int id)
	{
		_categoryService.TDelete(id);
		return Ok("Silme Başarılı");
	}

	[HttpPut]
	public IActionResult UpdateCategory(Category category)
	{
		_categoryService.TUpdate(category);
		return Ok("Güncelleme Yapıldı..");
	}
	[HttpGet("GetCategory")]
	public IActionResult GetCategory(int id)
	{
		var value = _categoryService.TGetById(id);
		return Ok(value);
	}
}
