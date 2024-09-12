using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RealEstate_Dapper_UI.Models;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        private readonly ApiSettings _settings;

        public StatisticsController(IHttpClientFactory httpClientFactory, ILoginService loginService, IOptions<ApiSettings> settings)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
            _settings = settings.Value;
        }

        public async Task<IActionResult> Index()
        {

            StatisticResponseValueName _name = new StatisticResponseValueName();
            StatisticResponseValue _valueName = new StatisticResponseValue();

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_settings.BaseUrl);

            for (int i = 0; i < _name.namesEng.Count(); i++)
            {
                var response = await client.GetAsync("Statistics/" + _name.namesEng[i]);
                var jsonData = await response.Content.ReadAsStringAsync();
                _valueName.pairs.Add(_name.namesTr[i], jsonData);
            }

            return View(_valueName);
        }
    }
}
