using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;
using RealEstate_Dapper_Api.Repositories.WhoWEAreRespository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhoWeAreDetailController : ControllerBase
    {
        private readonly IWhoWEAreDetailRespository _whoWEAreDetailRespository;

        public WhoWeAreDetailController(IWhoWEAreDetailRespository whoWEAreDetailRespository)
        {
            _whoWEAreDetailRespository = whoWEAreDetailRespository;
        }

        [HttpGet]
        public async Task<IActionResult> WhoWEAreDetailList()
        {
            var values = await _whoWEAreDetailRespository.GetAllWhoWeAreDetail();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWhoWEAreDetail(CreateWhoWeAreDetailDto  createWhoWeAreDetailDto)
        {
            await _whoWEAreDetailRespository.CreateWhoWeAreDetail(createWhoWeAreDetailDto);
            return Ok("Hakkımızda Kısmı Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteWhoWeAreDetail(int id)
        {
            await _whoWEAreDetailRespository.DeleteWhoWeAreDetail(id);
            return Ok("Hakkımızda Kısmı Başarılı Bir Şekilde Silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto)
        {
            await _whoWEAreDetailRespository.UpdateWhoWeAreDetail(updateWhoWeAreDetailDto);
            return Ok("Hakkımızda Kısmı Başarılı Bir Şekilde Güncellendi.");

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWhoWeAreDetail(int id)
        {
            var value = await _whoWEAreDetailRespository.GetByIdWhoWeAreDetail(id);
            return Ok(value);
        }
    }
}
