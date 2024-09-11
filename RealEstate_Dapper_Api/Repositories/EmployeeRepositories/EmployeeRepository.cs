using Dapper; 
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context _context;

        public EmployeeRepository(Context context)
        {
            _context = context;
        }
        public async Task CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            string query = "insert into Employee(Name,Title, Mail, PhoneNumber,ImageUrl,Status) Values (@name,@title,@mail,@phoneNumber,@imageUrl,@status)";
            var paremeters = new DynamicParameters();
            paremeters.Add("@name", createEmployeeDto.Name);
            paremeters.Add("@title", createEmployeeDto.Title);
            paremeters.Add("@mail", createEmployeeDto.Mail);
            paremeters.Add("@phoneNumber", createEmployeeDto.PhoneNumber);
            paremeters.Add("@imageUrl", createEmployeeDto.ImageUrl);
            paremeters.Add("@status", true);
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, paremeters);
            }
        }

        public async Task DeleteEmployee(int id)
        {
            string query = "Delete From Employee Where EmployeeID=@employeeID";
            var paremeters = new DynamicParameters();
            paremeters.Add("@employeeID", id);
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, paremeters);
            }
        }

        public async Task<List<ResultEmployeeDto>> GetAllEmployee()
        {
            string query = "Select * From Employee";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultEmployeeDto>(query);
                return values.ToList();
            }
        } 

        public async Task<GetByIdEmployeeDto> GetByIdEmployee(int id)
        {
            string query = "Select * From Employee Where EmployeeID=@employeeID";
            var param = new DynamicParameters();
            param.Add("@employeeID", id);

            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryFirstOrDefaultAsync<GetByIdEmployeeDto>(query, param);
                return values;
            }
        }

        public async Task UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            string query = "update Employee Set Name=@name,Title=@title ,Mail=@mail,PhoneNumber=@phoneNumber,ImageUrl=@imageUrl,Status=@status Where EmployeeID=@employeeID";

            var paremeters = new DynamicParameters();
            paremeters.Add("@name", updateEmployeeDto.Name);
            paremeters.Add("@title", updateEmployeeDto.Title);
            paremeters.Add("@mail", updateEmployeeDto.Mail);
            paremeters.Add("@phoneNumber", updateEmployeeDto.PhoneNumber);
            paremeters.Add("@imageUrl", updateEmployeeDto.ImageUrl);
            paremeters.Add("@status", updateEmployeeDto.Status);
            paremeters.Add("@employeeID", updateEmployeeDto.EmployeeID);
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, paremeters);
            }
        }
    }
}
