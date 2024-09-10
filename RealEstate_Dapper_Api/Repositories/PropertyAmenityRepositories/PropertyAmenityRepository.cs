using Dapper;
using RealEstate_Dapper_Api.Dtos.PropertyAmenityDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PropertyAmenityRepositories
{
    public class PropertyAmenityRepository : IPropertyAmenityRepository
    {
        private readonly Context _context;

        public PropertyAmenityRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultPropertyAmenityByStatusTrueDto>> ResulrPropertyAmenityByStatusTrue(int id)
        {
            string query = $@"SELECT PropertyAmenityId ,Title
                              FROM PropertyAmenity
                              inner join Amenity
                              On Amenity.AmenityId = PropertyAmenity.AmenityI
                              where PropertyId=@propertyId AND Status=1
                            ";
            var param = new DynamicParameters();
            param.Add("@propertyId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPropertyAmenityByStatusTrueDto>(query, param);
                return values.ToList();
            }
        }
    }
}
