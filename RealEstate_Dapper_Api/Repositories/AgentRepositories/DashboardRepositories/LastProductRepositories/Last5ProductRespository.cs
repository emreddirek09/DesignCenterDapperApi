using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDtos; 
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.AgentRepositories.DashboardRepositories.LastProductRepositories
{
    public class Last5ProductRespository : ILast5ProductRespository
    {
        private readonly Context _context;

        public Last5ProductRespository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultProductWithCategoryDto>> GetLast5ProductAsync(int id)
        {
            string query = @"Select top 5 ProductID,Title,Price,City,Disctrict,CategoryName,CoverImage,Address,Type,DealOfTheDay,Date from Product 
                               inner join Category on Product.ProductCategory=Category.CategoryID where EmployeeID=@employeeID order by ProductID desc";
            var param = new DynamicParameters();
            param.Add("@employeeID", id);
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryAsync<ResultProductWithCategoryDto>(query,param);
                return values.ToList();
            }
        }
    }
}
