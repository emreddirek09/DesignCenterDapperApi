using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.PropertyAmenityDtos;

namespace RealEstate_Dapper_UI.ViewComponents.PropertySingle
{
    public class _PropertyAmenityStatusTrueByPropertyIdComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _PropertyAmenityStatusTrueByPropertyIdComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private string _baseUrl = @"https://localhost:44319/api/";

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int id = 1;
            var client = _httpClientFactory.CreateClient();
            var responeseMessage = await client.GetAsync(_baseUrl + $"PropertyAmenites?id={id}");

            if (responeseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responeseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPropertyAmenityByStatusTrueDto>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
