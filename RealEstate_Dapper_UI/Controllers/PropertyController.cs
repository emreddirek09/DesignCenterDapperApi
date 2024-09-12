using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDetatilDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Models;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        private readonly ApiSettings _settings;

        public PropertyController(IHttpClientFactory httpClientFactory, ILoginService loginService, IOptions<ApiSettings> settings)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
            _settings = settings.Value;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_settings.BaseUrl);

            var responeseMessage = await client.GetAsync("ProductControllers/ProductListWithCategory");

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
            client.BaseAddress = new Uri(_settings.BaseUrl);

            var responeseMessage = await client.GetAsync("ProductControllers/ResultProductWithSearchList" + query);

            if (responeseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responeseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithSearchListDto>>(jsonData);
                return View(values);
            }
            return View();

        }

        [HttpGet("Property/{slug}/{id}")]
        public async Task<IActionResult> PropertySingle(string _slug, int id)
        {
            ViewBag.idd = id;

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_settings.BaseUrl);

            var responeseMessage = await client.GetAsync($"ProductControllers/GetProductByProductId/{id}");
            var responseProductDetail = await client.GetAsync($"ProductDetails/GetProductDetailsByProductId/{id}");
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

            if (valuesProductDetail != null)
            {
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
            }


            string slugFromTitle = CreateSlug(values.title);
            ViewBag.SlugUrl = slugFromTitle;


            return View();
        }


        private string CreateSlug(string title)
        {
            title = title.ToLowerInvariant(); // Küçük harfe çevir
            title = title.Replace(" ", "-"); // Boşlukları tire ile değiştir
            title = System.Text.RegularExpressions.Regex.Replace(title, @"[^a-z0-9\s-]", ""); // Geçersiz karakterleri kaldır
            title = System.Text.RegularExpressions.Regex.Replace(title, @"\s+", " ").Trim(); // Birden fazla boşluğu tek boşluğa indir ve kenar boşluklarını kaldır
            title = System.Text.RegularExpressions.Regex.Replace(title, @"\s", "-"); // Boşlukları tire ile değiştir

            return title;
        }
    }
}
