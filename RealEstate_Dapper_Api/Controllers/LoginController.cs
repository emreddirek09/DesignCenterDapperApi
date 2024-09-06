using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.LoginDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Tools; 

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(CreateLoginDto _createLoginDto)
        {
            string query = "select * from AppUser where Username=@username and Password=@password";
            var parameters = new DynamicParameters();
            parameters.Add("@username", _createLoginDto.UserName);
            parameters.Add("@password", _createLoginDto.Password);
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryFirstOrDefaultAsync<CreateLoginDto>(query,parameters);
                var values2 = await con.QueryFirstOrDefaultAsync<ResultLoginIdDto>(query, parameters);
                if (values !=null)
                {
                    GetCheckAppUserViewModel viewModel = new GetCheckAppUserViewModel();
                    viewModel.UserName = values.UserName;
                    viewModel.id = values2.UserId;
                    var _token = JwtTokenGenerator.GenerateToken(viewModel);
                    return Ok(_token);
                }                    
                else
                    return Ok("Başarısızzz!!!!!!!");


            }

        }
    }
}
