using Dapper;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.WhoWEAreRespository
{
    public class WhoWEAreDetailRespository : IWhoWEAreDetailRespository
    {
        private readonly Context _context;
        public WhoWEAreDetailRespository(Context context)
        {
            this._context = context;
        }

        public async void CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto)
        {
            string query = "insert into WhoWeAreDetail(Title,Subtitle,Description1,Description2) Values (@title,@subtitle,@description1,@description2)";
            var paremeters = new DynamicParameters();
            paremeters.Add("@title", createWhoWeAreDetailDto.Title);
            paremeters.Add("@subtitle", createWhoWeAreDetailDto.Subtitle);
            paremeters.Add("@description1", createWhoWeAreDetailDto.Description1);
            paremeters.Add("@description2", createWhoWeAreDetailDto.Description2);
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, paremeters);
            }
        }

        public async void DeleteWhoWeAreDetail(int id)
        {
            string query = "Delete From WhoWeAreDetail Where WhoWeAreDetailID=@whoWeAreDetailID";
            var paremeters = new DynamicParameters();
            paremeters.Add("@whoWeAreDetailID", id);
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, paremeters);
            }
        }

        public async Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetailAsync()
        {
            string query = "Select * From WhoWeAreDetail";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultWhoWeAreDetailDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdWhoWeAreDetailDto> GetByIdWhoWeAreDetail(int id)
        {
            string query = "Select * From WhoWeAreDetail Where WhoWeAreDetailID=@whoWeAreDetailID";
            var param = new DynamicParameters();
            param.Add("@whoWeAreDetailID", id);

            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryFirstOrDefaultAsync<GetByIdWhoWeAreDetailDto>(query, param);
                return values;
            }
        }

        public async void UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto)
        {
            string query = "update WhoWeAreDetail Set Title=@title,Subtitle=@subtitle,Description1=@description1,Description2=@description2 Where WhoWeAreDetailID=@whoWeAreDetailID";
            var paremeters = new DynamicParameters();
            paremeters.Add("@whoWeAreDetailID", updateWhoWeAreDetailDto.WhoWeAreDetailId);
            paremeters.Add("@title", updateWhoWeAreDetailDto.Title);
            paremeters.Add("@subtitle", updateWhoWeAreDetailDto.Subtitle);
            paremeters.Add("@description1", updateWhoWeAreDetailDto.Description1);
            paremeters.Add("@description2", updateWhoWeAreDetailDto.Description2);
           
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, paremeters);
            }
        }
    }
}
