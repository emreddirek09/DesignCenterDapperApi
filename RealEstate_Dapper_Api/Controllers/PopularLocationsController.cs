using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
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
            var value = await _popularLocationRespository.GetAllPopularLocation();
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto)
        {
            await _popularLocationRespository.CreatePopularLocation(createPopularLocationDto);
            return Ok("Popüler Lokasyonlar Detayları Kısmı Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeletePopularLocation(int id)
        {
            await _popularLocationRespository.DeletePopularLocation(id);
            return Ok("Popüler Lokasyonlar Detayları Kısmı Başarılı Bir Şekilde Silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto)
        {
            await _popularLocationRespository.UpdatePopularLocation(updatePopularLocationDto);
            return Ok("Popüler Lokasyonlar Detayları Kısmı Başarılı Bir Şekilde Güncellendi.");

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPopularLocation(int id)
        {
            var value = await _popularLocationRespository.GetPopularLocation(id);
            return Ok(value);
        }
    }
}
