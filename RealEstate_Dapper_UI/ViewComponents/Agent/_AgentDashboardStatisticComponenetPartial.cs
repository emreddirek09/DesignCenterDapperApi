using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RealEstate_Dapper_UI.Models;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.ViewComponents.Agent
{
    public class _AgentDashboardStatisticComponenetPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        private readonly ApiSettings _settings;

        public _AgentDashboardStatisticComponenetPartial(IHttpClientFactory httpClientFactory, ILoginService loginService, IOptions<ApiSettings> settings)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
            _settings = settings.Value;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_settings.BaseUrl);

            var id = _loginService.GetUserId;
            #region ToplamİlanSayısı
            var responseMessage1 = await client.GetAsync("AgentDashboardStatistics/AllProductCount");
            var json1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.productCount = json1;
            #endregion

            #region KullanıcınınToplamİlanSayısı
            var responseMessage2 = await client.GetAsync($"AgentDashboardStatistics/ProductCountByEmployeeId/{id}");
            var json2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.employeeByProductCount = json2;
            #endregion

            #region ProductCountByStatusTrue
            var responseMessage3 = await client.GetAsync($"AgentDashboardStatistics/ProductCountByStatusTrue/{id}");
            var json3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.productCountByEmployeeByStatusTrue = json3;
            #endregion

            #region ProductCountByStatusFalse
            var responseMessage4 = await client.GetAsync($"AgentDashboardStatistics/ProductCountByStatusFalse/{id}");
            var json4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.productCountByEmployeeByStatusFalse = json4;
            #endregion

            return View();

        }
    }
}
