using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.CategoryDtos;

namespace RealEstate_Dapper_UI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        private string _baseUrl = @"https://localhost:44319/api/";

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responeseMessage = await client.GetAsync(_baseUrl + "Categories");

            if (responeseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responeseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }

            return View();
        }
        [HttpGet]
        public PartialViewResult PartialSearch()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult PartialSearch(string _search, string _category, string _city)
        {
            TempData["_search"] = _search;
            TempData["_category"] = _category;
            TempData["_city"] = _city;
            return RedirectToAction("PropertyListWithSearch", "Property");
        }
    }
}
