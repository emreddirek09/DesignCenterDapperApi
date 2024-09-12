using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.MessageDtos;
using RealEstate_Dapper_UI.Models;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.Areas.Agent.ViewComponents.AgentNavbarViewComponents
{
    public class _AgentNavbarLast3ComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        private readonly ApiSettings _settings;

        public _AgentNavbarLast3ComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService, IOptions<ApiSettings> settings)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
            _settings = settings.Value;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = _loginService.GetUserId;

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_settings.BaseUrl);

            var responeseMessage = await client.GetAsync($"Messages?id={id}");

            if (responeseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responeseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultInBoxMessageDto>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
