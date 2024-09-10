using Dapper;
using RealEstate_Dapper_Api.Dtos.AppUserDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.AppUserRepositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly Context _context;

        public AppUserRepository(Context context)
        {
            _context = context;
        }
        public async Task<GetAppUserByProductDto> GetAppUserByProductId(int id)
        {
            string query = "Select * From AppUser Where UserId=@userId";
            var param = new DynamicParameters();
            param.Add("@userId", id);

            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryFirstOrDefaultAsync<GetAppUserByProductDto>(query, param);
                return values;
            }
        }
    }
}
