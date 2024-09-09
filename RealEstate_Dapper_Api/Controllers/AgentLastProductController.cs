using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.AgentRepositories.DashboardRepositories.LastProductRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentLastProductController : ControllerBase
    {
        private readonly ILast5ProductRespository _last5ProductRespository;

        public AgentLastProductController(ILast5ProductRespository last5ProductRespository)
        {
            _last5ProductRespository = last5ProductRespository;
        }
        [HttpGet]

        public async Task<IActionResult> GetLast5ProductAsync(int id)
        {
            var values = await _last5ProductRespository.GetLast5ProductAsync(id);
            return Ok(values);
        }
    }
}
