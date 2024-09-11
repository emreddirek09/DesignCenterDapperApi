using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDetatilDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;

namespace RealEstate_Dapper_UI.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PropertyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private string _baseUrl = $"https://localhost:44319/api/";
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responeseMessage = await client.GetAsync(_baseUrl + "ProductControllers/ProductListWithCategory");

            if (responeseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responeseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        public async Task<IActionResult> PropertyListWithSearch(string? searchKeyValue, string? propertyCategoryId, string? city)
        {
            searchKeyValue = TempData["_search"].ToString();
            propertyCategoryId = TempData["_category"].ToString();
            city = TempData["_city"].ToString();

            string query = "";

            if (!String.IsNullOrEmpty(searchKeyValue) || !String.IsNullOrEmpty(propertyCategoryId) || !String.IsNullOrEmpty(city))
            {
                query += "?";

                if (!String.IsNullOrEmpty(searchKeyValue))
                {
                    query += $"searchKeyValue={searchKeyValue}";

                    if (!String.IsNullOrEmpty(propertyCategoryId))
                    {
                        query += $"&propertyCategoryId={propertyCategoryId}";
                    }
                    if (!city.IsNullOrEmpty())
                    {
                        query += $"&city={city}";
                    }
                }
                else if (!String.IsNullOrEmpty(propertyCategoryId))
                {

                    query += $"propertyCategoryId={propertyCategoryId}";

                    if (!city.IsNullOrEmpty())
                    {
                        query += $"&city={city}";
                    }
                }
                else if (!String.IsNullOrEmpty(city))
                {
                    query += $"city={city}";
                }

            }

            //https://localhost:44319/api/ProductControllers/ResultProductWithSearchList?searchKeyValue=Daire&propertyCategoryId=1&city=izmir


            var client = _httpClientFactory.CreateClient();
            var responeseMessage = await client.GetAsync(_baseUrl + "ProductControllers/ResultProductWithSearchList" + query);

            if (responeseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responeseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithSearchListDto>>(jsonData);
                return View(values);
            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> PropertySingle(int id)
        {
            id = 1;
            var client = _httpClientFactory.CreateClient();
            var responeseMessage = await client.GetAsync(_baseUrl + $"ProductControllers/GetProductByProductId/{id}");
            var responseProductDetail = await client.GetAsync(_baseUrl + $"ProductDetails/GetProductDetailsByProductId/{id}");
            var jsonData = await responeseMessage.Content.ReadAsStringAsync();
            var jsonDataProductDetail = await responseProductDetail.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultProductDto>(jsonData);
            var valuesProductDetail = JsonConvert.DeserializeObject<GetProductDetailByProductId>(jsonDataProductDetail);
            ViewBag.titleOlmuyoSadeceÖzelİsim = values.title;
            ViewBag.price = values.price;
            ViewBag.city = values.city;
            ViewBag.disctrict = values.disctrict;
            ViewBag.address = values.address;
            ViewBag.type = values.type;
            ViewBag.description = values.description;
            ViewBag.Date = values.Date;
            ViewBag.datediff = (values.Date.Month - System.DateTime.UtcNow.Month) == 0 ? 1 : values.Date.Month - System.DateTime.UtcNow.Month;

            ViewBag.productID = valuesProductDetail.productID;//
            ViewBag.bathCount = valuesProductDetail.bathCount;//
            ViewBag.roomCount = valuesProductDetail.roomCount;
            ViewBag.bedRoomCount = valuesProductDetail.bedRoomCount;//
            ViewBag.buildYear = valuesProductDetail.buildYear;//
            ViewBag.garageSize = valuesProductDetail.garageSize;//
            ViewBag.location = valuesProductDetail.location;
            ViewBag.price = valuesProductDetail.price;
            ViewBag.productSize = valuesProductDetail.productSize;
            ViewBag.videoUrl = valuesProductDetail.videoUrl;
            return View();
        }
    }
}
