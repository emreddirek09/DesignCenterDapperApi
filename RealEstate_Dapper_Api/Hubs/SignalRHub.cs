using Microsoft.AspNetCore.SignalR;

namespace RealEstate_Dapper_Api.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SignalRHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private string _baseUrl = "";

        public async Task SendCategoryCount()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44319/api/Statistics/CategoryCount");
            var value = await response.Content.ReadAsStringAsync();
             await Clients.All.SendAsync("ReceiveCategoryCount", value);


        } 

    }
}
