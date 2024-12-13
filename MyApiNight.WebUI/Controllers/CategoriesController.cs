using Microsoft.AspNetCore.Mvc;
using MyApiNight.WebUI.Dtos;
using Newtonsoft.Json;
using System.Text;

namespace MyApiNight.WebUI.Controllers;
public class CategoriesController : Controller
{
	private readonly IHttpClientFactory _httpClientFactory;

	public CategoriesController(IHttpClientFactory httpClientFactory)
	{
		_httpClientFactory = httpClientFactory;
	}

	public async Task<IActionResult> CategoryList()
	{
		var client = _httpClientFactory.CreateClient();
		var responseMessage = await client.GetAsync("https://localhost:7199/api/Category");
		if (responseMessage.IsSuccessStatusCode)
		{
			var jsonData = await responseMessage.Content.ReadAsStringAsync(); //json veri yakaladık hafızaya aldık
			var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData); //DeserializeObject json datasını string çevirir
			return View(values);
		}
		return View();
	}

	[HttpGet]
	public IActionResult CreateCategory()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> CreateCategory(CreateCategoryDto dto)
	{
		var client = _httpClientFactory.CreateClient();
		var jsonData = JsonConvert.SerializeObject(dto); //string datayı json formatına çevirir
		StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //koddaki türkçe karakterleri Encoding.UTF8 çevirir.
		var responseMessage = await client.PostAsync("https://localhost:7199/api/Category", stringContent);
		if (responseMessage.IsSuccessStatusCode)
		{
			return RedirectToAction("CategoryList");
		}
		return View();
	}
	public async Task<IActionResult> DeleteCategory(int id)
	{
		var client = _httpClientFactory.CreateClient();
		var responseMessage = await client.DeleteAsync("https://localhost:7199/api/Category?id=" + id);
		if (responseMessage.IsSuccessStatusCode)
		{
			return RedirectToAction("CategoryList");
		}
		return View();
	}
	[HttpGet]
	public async Task<IActionResult> UpdateCategory(int id)
	{
		var client = _httpClientFactory.CreateClient();
		var response = await client.GetAsync("https://localhost:7199/api/Category/GetCategory?id=" + id);
		if ((response.IsSuccessStatusCode))
		{
			var jsonData = await response.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
			return View(values);
		}
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> UpdateCategory(UpdateCategoryDto dto)
	{
		var client = _httpClientFactory.CreateClient();
		var jsonData = JsonConvert.SerializeObject(dto);
		StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
		var response = await client.PutAsync("https://localhost:7199/api/Category/", stringContent);
		if (response.IsSuccessStatusCode)
		{
			return RedirectToAction("CategoryList");
		}
		return View();
	}
}
