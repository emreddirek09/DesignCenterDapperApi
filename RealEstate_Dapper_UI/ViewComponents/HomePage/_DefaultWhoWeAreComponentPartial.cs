using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ServiceDtos;
using RealEstate_Dapper_UI.Dtos.WhoWeAreDtos;
using RealEstate_Dapper_UI.Models;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultWhoWeAreComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        private readonly ApiSettings _settings;

        public _DefaultWhoWeAreComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService, IOptions<ApiSettings> settings)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
            _settings = settings.Value;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_settings.BaseUrl);


            var responseMessage = await client.GetAsync("WhoWeAreDetail");
            var responeseMessage2 = await client.GetAsync("Services");

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
