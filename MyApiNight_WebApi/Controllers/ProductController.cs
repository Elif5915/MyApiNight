using Microsoft.AspNetCore.Mvc;
using MyApiNight_BusinessLayer.Abstract;
using MyApiNight_EntityLayer.Concrete;

namespace MyApiNight_WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
	private readonly IProductService _productService;

	public ProductController(IProductService productService)
	{
		_productService = productService;
	}
	[HttpGet]
	public IActionResult ProductList()
	{
		var values = _productService.TGetAll();
		return Ok(values);
	}

	[HttpPost]
	public IActionResult CreateProduct(Product product)
	{
		_productService.TInsert(product);
		return Ok("Ekleme Başarılı..");
	}

	[HttpDelete]
	public IActionResult DeleteProduct(int id)
	{
		_productService.TDelete(id);
		return Ok("Silme Başarılı");
	}

	[HttpGet("GetProduct")]
	public IActionResult GetProduct(int id)
	{
		var value = _productService.TGetById(id);
		return Ok(value);
	}
	[HttpPut]
	public IActionResult UpdateProduct(Product product)
	{
		_productService.TUpdate(product);
		return Ok("Güncelleme başarılı...");
	}

	[HttpGet("ProductCount")]

	public IActionResult ProductCount()
	{
		return Ok(_productService.TGetProductCount());
	}
}
