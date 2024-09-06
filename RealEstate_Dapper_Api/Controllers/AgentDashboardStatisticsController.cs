using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.AgentRepositories.DashboardRepositories.StatisticsRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentDashboardStatisticsController : ControllerBase
    {
        private readonly IAgentStatisticsRepository _statisticsRepository;

        public AgentDashboardStatisticsController(IAgentStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }
        [HttpGet("ProductCountByEmployeeId/{id}")]
        public IActionResult ProductCountByEmployeeId(int id)
        {
            return Ok(_statisticsRepository.ProductCountByEmployeeId(id));
        }
        [HttpGet("ProductCountByStatusTrue/{id}")]
        public IActionResult ProductCountByStatusTrue(int id)
        {
            return Ok(_statisticsRepository.ProductCountByStatusTrue(id));
        }
        [HttpGet("ProductCountByStatusFalse/{id}")]
        public IActionResult ProductCountByStatusFalse(int id)
        {
            return Ok(_statisticsRepository.ProductCountByStatusFalse(id));
        }
        [HttpGet("AllProductCount")]
        public IActionResult AllProductCount()
        {
            return Ok(_statisticsRepository.AllProductCount());
        }

    }
}
