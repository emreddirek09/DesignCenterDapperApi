using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.PropertyAmenityRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyAmenitesController : ControllerBase
    {
        private readonly IPropertyAmenityRepository _propertyAmenityRepository;

        public PropertyAmenitesController(IPropertyAmenityRepository propertyAmenityRepository)
        {
            _propertyAmenityRepository = propertyAmenityRepository;
        }
        [HttpGet]
        public async Task<IActionResult> ResultPropertyAmenityByStatusTrue(int id)
        {
            var values = await _propertyAmenityRepository.ResulrPropertyAmenityByStatusTrue(id);
            return Ok(values);
        }
    }
}
