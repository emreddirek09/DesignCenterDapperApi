using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.CategoryDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;

namespace RealEstate_Dapper_UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        private string _baseUrl = @"https://localhost:44319/api/";

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(_baseUrl + "ProductControllers/ProductListWithCategory");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(json);
                return View(values);
            }
            return View();
        }
        [HttpGet]

        public async Task<IActionResult> CreateProduct()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(_baseUrl + "Categories");

            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(json);

            List<SelectListItem> categoryValues = (from x in values.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName.ToString(),
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.CategoryValues = categoryValues;

            return View();
        }

        public async Task<IActionResult> ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(_baseUrl + $"ProductControllers/ProductDealOfTheDayStatusChangeToFalse/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(_baseUrl + $"ProductControllers/ProductDealOfTheDayStatusChangeToTrue/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
