using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RealEstate_Dapper_UI.Models;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.ViewComponents.Dashboard
{
    public class _DashboardStatisticComponenetPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        private readonly ApiSettings _settings;

        public _DashboardStatisticComponenetPartial(IHttpClientFactory httpClientFactory, ILoginService loginService, IOptions<ApiSettings> settings)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
            _settings = settings.Value;
        } 

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_settings.BaseUrl);

            #region ToplamİlanSayısı
            var responseMessage1 = await client.GetAsync("Statistics/ProductCount");
            var json1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.productCount = json1;
            #endregion

            #region EnBaşarılıPersonel
            var responseMessage2 = await client.GetAsync("Statistics/EmployeeNameByMaxProductCount");
            var json2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.employeeNameByMaxProductCount = json2;
            #endregion

            #region İlandakiŞehirSayısı
            var responseMessage3 = await client.GetAsync("Statistics/DifferentCityCount");
            var json3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.ilandakiŞehirSayısı = json3;
            #endregion

            #region OrtalamaKiraSayısı
            var responseMessage4 = await client.GetAsync("Statistics/AverageProductPriceByRent");
            var json4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.ortalamaKiraSayısı = json4;
            #endregion

            return View();

        }
    }
}
