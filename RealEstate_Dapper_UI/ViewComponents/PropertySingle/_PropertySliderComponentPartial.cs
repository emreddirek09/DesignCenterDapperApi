using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.PropertyImageDtos;

namespace RealEstate_Dapper_UI.ViewComponents.PropertySingle
{
    public class _PropertySliderComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _PropertySliderComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        private string _baseUrl = @"https://localhost:44319/api/";
        public async Task<IViewComponentResult> InvokeAsync()
        {
            int id = 1;
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(_baseUrl + $"ProductImages?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<PropertyImageDto>>(json);
                return View(values);
            }
            return View();
        }
    }
}
