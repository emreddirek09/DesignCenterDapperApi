using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.AppUserDtos;
using RealEstate_Dapper_UI.Dtos.PropertyImageDtos;

namespace RealEstate_Dapper_UI.ViewComponents.PropertySingle
{
    public class _PropertyAppUserComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _PropertyAppUserComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        private string _baseUrl = @"https://localhost:44319/api/";
        public async Task<IViewComponentResult> InvokeAsync()
        {
            int id = 1;
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(_baseUrl + $"AppUsers?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetAppUserByProductIdDto>(json);
                return View(values);
            }
            return View();
        }
    }
}
