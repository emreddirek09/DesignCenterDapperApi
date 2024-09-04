using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ServiceRespository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly Context _context;

        public ServiceRepository(Context context)
        {
            _context = context;
        }

        public async void CreateService(CreateServiceDto createServiceDto)
        {
            string query = "insert into Service (ServiceName,ServiceStatus) Values (@serviceName,@serviceStatus)";
            var paremeters = new DynamicParameters();
            paremeters.Add("@serviceName", createServiceDto.ServiceName);
            paremeters.Add("@serviceStatus", true);
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, paremeters);
            }
        }

        public async void DeleteService(int id)
        {
            string query = "Delete From Service Where ServiceID=@serviceID";
            var paremeters = new DynamicParameters();
            paremeters.Add("@serviceID", id);
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, paremeters);
            }
        }

        public async Task<List<ResultServiceDto>> GetAllServiceAsync()
        {
            string query = "Select * From Service";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultServiceDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdServiceDto> GetService(int id)
        {
            string query = "Select * From Service Where ServiceID=@serviceID";
            var param = new DynamicParameters();
            param.Add("@serviceID", id);

            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryFirstOrDefaultAsync<GetByIdServiceDto>(query, param);
                return values;
            }
        }

        public async void UpdateService(UpdateServiceDto updateServiceDto)
        {
            string query = @"update Service Set ServiceName=@serviceName,ServiceStatus=@serviceStatus Where ServiceID=@serviceID";
            var paremeters = new DynamicParameters();
            paremeters.Add("@serviceID", updateServiceDto.ServiceID);
            paremeters.Add("@serviceName", updateServiceDto.ServiceName);
            paremeters.Add("@serviceStatus", updateServiceDto.ServiceStatus); 

            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, paremeters);
            }
        }
    }
}
