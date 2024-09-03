using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.WhoWeAreDtos;
using System.Text;

namespace RealEstate_Dapper_UI.Controllers
{
    public class WhoWeAreController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private string _baseUrl = "https://localhost:44319/api/";

        public WhoWeAreController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responeseMessage = await client.GetAsync(_baseUrl + "WhoWeAreDetail");

            if (responeseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responeseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultWhoWeAreDetailDto>>(jsonData);
                return View(values);
            }

            return View();
        }
        [HttpGet]
        public IActionResult CreateWhoWeAreDetail() { return View(); }

        [HttpPost]

        public async Task<IActionResult> CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jasonData = JsonConvert.SerializeObject(createWhoWeAreDetailDto);
            StringContent stringContent = new StringContent(jasonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync(_baseUrl + "WhoWeAreDetail", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();


        }
        public async Task<IActionResult> DeleteWhoWeAreDetail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync(_baseUrl + "WhoWeAreDetail/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpGet]
        public async Task<IActionResult> UpdateWhoWeAreDetail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(_baseUrl + "WhoWeAreDetail/" + id);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var categoryDto = JsonConvert.DeserializeObject<UpdateWhoWeAreDetailDto>(json);
                return View(categoryDto);
            }
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(updateWhoWeAreDetailDto);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync(_baseUrl + "WhoWeAreDetail/", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

