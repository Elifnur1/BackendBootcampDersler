using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _29_12_2024.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using System.Text;

namespace _29_12_2024.Controllers;

public class HomeController : Controller
{

    private readonly HttpClient _httpClient;

    public HomeController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("FafeStoreApi");
    }

    public async Task<IActionResult> Index()
    {

        var responseMessage = await _httpClient.GetAsync("products");
        string contentResponse = await responseMessage.Content.ReadAsStringAsync();
        List<Product>? response = JsonConvert.DeserializeObject<List<Product>>(contentResponse);

        return View(response);
    }
    public async Task<IActionResult> Details(int id)
    {
        var responseMessage = await _httpClient.GetAsync($"products/id/{id}");
        var contentResponse = await responseMessage.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Product>(contentResponse);
        return View(response);
    }
    public async Task<IActionResult> GetCategories()

    {
        var responseMessage = await _httpClient.GetAsync("products/categories");
        var contentResponse = await responseMessage.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<List<string>>(contentResponse);
        return View(response);
    }
    public async Task<IActionResult> AddProduct()
    {
        var responseMessage = await _httpClient.GetAsync("products/categories");
        var contentResponse = await responseMessage.Content.ReadAsStringAsync();
        var categories = JsonConvert.DeserializeObject<List<string>>(contentResponse);
        ViewBag.categories = categories;
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> AddProduct(Product product)
    {
        if (ModelState.IsValid)
        {
            // var response = await _httpClient.PostAsJsonAsync("products", product);

           var serializeProduct=JsonConvert.SerializeObject(product);
            HttpContent content=new StringContent(serializeProduct,Encoding.UTF8,"application/json");
            var response =await _httpClient.PostAsync("products",content);
            var newProduct = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Product>(newProduct);
            return Json(result);
        }
        var responseMessage = await _httpClient.GetAsync("products/categories");
        var contentResponse = await responseMessage.Content.ReadAsStringAsync();
        var categories = JsonConvert.DeserializeObject<List<string>>(contentResponse);
        ViewBag.categories = categories;
        return View(product);
    }



}
