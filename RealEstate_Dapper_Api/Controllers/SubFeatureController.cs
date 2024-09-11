using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.SubFeatureRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubFeatureController : ControllerBase
    {
        private readonly ISubFeatureRespository _subFeatureRespository;

        public SubFeatureController(ISubFeatureRespository subFeatureRespository)
        {
            _subFeatureRespository = subFeatureRespository;
        }
        [HttpGet]
        public async Task<IActionResult> GetSubFeatureList()
        {
            var values = await _subFeatureRespository.GetAllSubFeatureAsync();  
            return Ok(values);
        }
    }
}
