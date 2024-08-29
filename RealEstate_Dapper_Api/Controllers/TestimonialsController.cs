using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.TestimonialRespositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ITestimonialRespository _testimonialRespository;

        public TestimonialsController(ITestimonialRespository testimonialRespository)
        {
            _testimonialRespository = testimonialRespository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTestimonialList()
        {
            var value = await _testimonialRespository.GetAllTestimonialAsync();
            return Ok(value);
        }
    }
}
