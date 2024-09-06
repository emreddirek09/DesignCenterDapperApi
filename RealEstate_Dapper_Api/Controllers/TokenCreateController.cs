using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Tools;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenCreateController : ControllerBase
    {
        [HttpPost]

       public IActionResult CreateToken(GetCheckAppUserViewModel _model)
        {
            var _values = JwtTokenGenerator.GenerateToken(_model);
            return Ok(_values);
        }
    }
}
