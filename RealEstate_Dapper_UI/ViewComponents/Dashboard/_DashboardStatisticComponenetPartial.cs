using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.ViewComponents.Dashboard
{
    public class _DashboardStatisticComponenetPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardStatisticComponenetPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        private string _baseUrl = @"https://localhost:44319/api/Statistics/";

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            #region ToplamİlanSayısı
            var responseMessage1 = await client.GetAsync(_baseUrl + "ProductCount");
            var json1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.productCount = json1;
            #endregion

            #region EnBaşarılıPersonel
            var responseMessage2 = await client.GetAsync(_baseUrl + "EmployeeNameByMaxProductCount");
            var json2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.employeeNameByMaxProductCount = json2;
            #endregion

            #region İlandakiŞehirSayısı
            var responseMessage3 = await client.GetAsync(_baseUrl + "DifferentCityCount");
            var json3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.ilandakiŞehirSayısı = json3;
            #endregion

            #region OrtalamaKiraSayısı
            var responseMessage4 = await client.GetAsync(_baseUrl + "AverageProductPriceByRent");
            var json4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.ortalamaKiraSayısı = json4;
            #endregion

            return View();

        }
    }
}
