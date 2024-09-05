using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public class ProductRespository : IProductRepository
    {
        private readonly Context _context;

        public ProductRespository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            string query = "Select * from Product";
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryAsync<ResultProductDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetLast5ProductAsync()
        {
            string query = @"Select top 5 ProductID,Title,Price,City,Disctrict,CategoryName,CoverImage,Address,Type,DealOfTheDay,Date from Product 
                               inner join Category on Product.ProductCategory=Category.CategoryID order by ProductID desc"; 
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetResultProductWithCategoryDtoAsync()
        {
            string query = @"Select ProductID,Title,Price,City,Disctrict,CategoryName,CoverImage,Address,Type,DealOfTheDay,Date from Product 
                               inner join Category on Product.ProductCategory=Category.CategoryID ";
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async void ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            string query = "update Product Set DealOfTheDay=@dealOfTheDay Where ProductID=@productID";

            var paremeters = new DynamicParameters(); 
            paremeters.Add("@dealOfTheDay",false);
            paremeters.Add("@productID", id);

            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, paremeters);
            }
        }

        public async void ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            string query = "update Product Set DealOfTheDay=@dealOfTheDay Where ProductID=@productID";

            var paremeters = new DynamicParameters();
            paremeters.Add("@dealOfTheDay", true);
            paremeters.Add("@productID", id);

            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, paremeters);
            }
        }
    }
}
