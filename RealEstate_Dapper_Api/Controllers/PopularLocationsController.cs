using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.PopularLocationRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopularLocationsController : ControllerBase
    {
        private readonly IPopularLocationRespository _popularLocationRespository;

        public PopularLocationsController(IPopularLocationRespository popularLocationRespository)
        {
            _popularLocationRespository = popularLocationRespository;
        }

        [HttpGet]
        public async Task<IActionResult> PopularLocationList() 
        {
            var value = await _popularLocationRespository.GetAllPopularLocationAsync();
            return Ok(value);
        }
    }
}
