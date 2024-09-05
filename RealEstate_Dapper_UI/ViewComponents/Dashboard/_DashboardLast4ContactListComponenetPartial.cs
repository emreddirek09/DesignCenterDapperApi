using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ContactDtos;

namespace RealEstate_Dapper_UI.ViewComponents.Dashboard
{
    public class _DashboardLast4ContactListComponenetPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardLast4ContactListComponenetPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private string _subtitle = "https://localhost:44319/api/";
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responeseMessage = await client.GetAsync(_subtitle+"Contact/GetLast4Contact");

            if (responeseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responeseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<Last4ContactResultDto>>(jsonData);
                return View(values);
            }

            return View();
        }

    }
}
