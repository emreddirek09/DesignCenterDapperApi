using Dapper;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Models.DapperContext; 

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepositories
{
    public class BottomGridRepository : IBottomGridRepository
    {
        private readonly Context _context;

        public BottomGridRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateBottomGrid(CreateBottomGridDto createBottomGridDto)
        {
            string query = "insert into BottomGrid (Icon,Title,Description) Values (@icon,@title,@description)";
            var paremeters = new DynamicParameters();
            paremeters.Add("@icon", createBottomGridDto.Icon);
            paremeters.Add("@title", createBottomGridDto.Title);
            paremeters.Add("@description", createBottomGridDto.Description);
             using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, paremeters);
            }
        }

        public async Task DeleteBottomGrid(int id)
        {
            string query = "Delete From BottomGrid Where BottomGridID=@bottomGridID";
            var paremeters = new DynamicParameters();
            paremeters.Add("@bottomGridID", id);
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, paremeters);
            }
        }

        public async Task<List<ResultBottomGridDto>> GetAllBottomGrid()
        {
            string query = "Select * From BottomGrid";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultBottomGridDto>(query);
                return values.ToList();
            }
        } 

        public async Task<GetBottomGridDto> GetByIdBottomGrid(int id)
        {
            string query = "Select * From BottomGrid Where BottomGridID=@bottomGridID";
            var param = new DynamicParameters();
            param.Add("@bottomGridID", id);

            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryFirstOrDefaultAsync<GetBottomGridDto>(query, param);
                return values;
            }
        }

        public async Task UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto)
        {
            string query = @"update BottomGrid Set Icon=@icon,Title=@title,Description=@description Where BottomGridID=@bottomGridID";
            var paremeters = new DynamicParameters();
            paremeters.Add("@bottomGridID", updateBottomGridDto.BottomGridID);
            paremeters.Add("@icon", updateBottomGridDto.Icon);
            paremeters.Add("@title", updateBottomGridDto.Title);
            paremeters.Add("@description", updateBottomGridDto.Description);

            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, paremeters);
            }
        }
    }
}
