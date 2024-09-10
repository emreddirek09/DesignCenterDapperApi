using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductImagesDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductImageRepositories
{
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly Context _context;

        public ProductImageRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<GetProductImageByProductIdDto>> GetProductImageByProductIdAsync(int id)
        {
            string query = "Select * From ProductImage Where ProductId=@productId";
            var param = new DynamicParameters();
            param.Add("@productId", id);

            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryAsync<GetProductImageByProductIdDto>(query, param);
                return values.ToList();
            }
        }
    }
}
