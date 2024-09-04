using Dapper; 
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepositories
{
    public class PopularLocationRespository : IPopularLocationRespository
    {
        private readonly Context _context;

        public PopularLocationRespository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync()
        {
            string query = "Select * From PopularLocation";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPopularLocationDto>(query);
                return values.ToList();
            }
        }

        public async void CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto)
        {
            string query = "insert into PopularLocation (CityName,ImageUrl) Values (@cityName,@imageUrl)";
            var paremeters = new DynamicParameters();
            paremeters.Add("@cityName", createPopularLocationDto.CityName);
            paremeters.Add("@imageUrl", createPopularLocationDto.ImageUrl);
    
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, paremeters);
            }
        }

        public async void DeletePopularLocation(int id)
        {
            string query = "Delete From PopularLocation Where LocationID=@locationID";
            var paremeters = new DynamicParameters();
            paremeters.Add("@locationID", id);
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, paremeters);
            }
        }


        public async Task<GetByIdPopularLocationDto> GetPopularLocation(int id)
        { 
            string query = "Select * From PopularLocation Where LocationID=@locationID";
            var param = new DynamicParameters();
            param.Add("@locationID", id);

            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryFirstOrDefaultAsync<GetByIdPopularLocationDto>(query, param);
                return values;
            }
        }

        public async void UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto)
        {
            string query = @"update PopularLocation Set CityName=@cityName,ImageUrl=@imageUrl Where LocationID=@locationID";
            var paremeters = new DynamicParameters();
            paremeters.Add("@locationID", updatePopularLocationDto.LocationID);
            paremeters.Add("@cityName", updatePopularLocationDto.CityName);
            paremeters.Add("@imageUrl", updatePopularLocationDto.ImageUrl);

            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, paremeters);
            }
        }
    }
}
