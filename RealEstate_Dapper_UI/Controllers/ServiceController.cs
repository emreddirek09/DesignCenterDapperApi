using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ServiceDtos;
using System.Text;

namespace RealEstate_Dapper_UI.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private string _baseUrl = "https://localhost:44319/api/";

        public ServiceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responeseMessage = await client.GetAsync(_baseUrl + "Services");

            if (responeseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responeseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
                return View(values);
            }

            return View();
        }
        [HttpGet]
        public IActionResult CreateService() { return View(); }

        [HttpPost]

        public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
        {
            createServiceDto.ServiceStatus = true;
            var client = _httpClientFactory.CreateClient();
            var jasonData = JsonConvert.SerializeObject(createServiceDto);
            StringContent stringContent = new StringContent(jasonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync(_baseUrl + "Services", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();


        }
        public async Task<IActionResult> DeleteService(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync(_baseUrl + "Services/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(_baseUrl + "Services/" + id);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var categoryDto = JsonConvert.DeserializeObject<UpdateServiceDto>(json);
                return View(categoryDto);
            }
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(updateServiceDto);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync(_baseUrl + "Services", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

