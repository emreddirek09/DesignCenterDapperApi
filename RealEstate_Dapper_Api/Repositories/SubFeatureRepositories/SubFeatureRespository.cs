using Dapper;
using RealEstate_Dapper_Api.Dtos.ResultSubFeatureDto;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.SubFeatureRepositories
{
    public class SubFeatureRespository : ISubFeatureRespository
    {
        private readonly Context _context;

        public SubFeatureRespository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultSubFeatureDto>> GetAllSubFeatureAsync()
        {
            string query = "select * from SubFeature";
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryAsync<ResultSubFeatureDto>(query);
                return values.ToList();
            }
            
        }
    }
}
