using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.ViewComponents.Agent
{
    public class _AgentDashboardStatisticComponenetPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        private string _baseUrl = @"https://localhost:44319/api/AgentDashboardStatistics/";


        public _AgentDashboardStatisticComponenetPartial(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var id = _loginService.GetUserId;
            #region ToplamİlanSayısı
            var responseMessage1 = await client.GetAsync(_baseUrl + "AllProductCount");
            var json1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.productCount = json1;
            #endregion

            #region KullanıcınınToplamİlanSayısı
            var responseMessage2 = await client.GetAsync(_baseUrl + $"ProductCountByEmployeeId/{id}");
            var json2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.employeeByProductCount = json2;
            #endregion

            #region ProductCountByStatusTrue
            var responseMessage3 = await client.GetAsync(_baseUrl + $"ProductCountByStatusTrue/{id}");
            var json3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.productCountByEmployeeByStatusTrue = json3;
            #endregion

            #region ProductCountByStatusFalse
            var responseMessage4 = await client.GetAsync(_baseUrl + $"ProductCountByStatusFalse/{id}");
            var json4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.productCountByEmployeeByStatusFalse = json4;
            #endregion

            return View();

        }
    }
}
