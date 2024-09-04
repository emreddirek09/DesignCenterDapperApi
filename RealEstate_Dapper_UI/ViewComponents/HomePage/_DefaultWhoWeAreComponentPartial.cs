using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ServiceDtos;
using RealEstate_Dapper_UI.Dtos.WhoWeAreDtos;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultWhoWeAreComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultWhoWeAreComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var client2 = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:44319/api/WhoWeAreDetail");
            var responeseMessage2 = await client.GetAsync("https://localhost:44319/api/Services");

            if (responseMessage.IsSuccessStatusCode && responeseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData2 = await responeseMessage2.Content.ReadAsStringAsync();

                var weAreDetailDto = JsonConvert.DeserializeObject<List<ResultWhoWeAreDetailDto>>(jsonData);
                var values2 = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData2);

                ViewBag.Title = weAreDetailDto.Select(x => x.Title).FirstOrDefault();
                ViewBag.Subtitle = weAreDetailDto.Select(x => x.Subtitle).FirstOrDefault();
                ViewBag.Description1 = weAreDetailDto.Select(x => x.Description1).FirstOrDefault();
                ViewBag.Description2 = weAreDetailDto.Select(x => x.Description2).FirstOrDefault();
                return View(values2);
            }

            return View();
        }
    }
}
