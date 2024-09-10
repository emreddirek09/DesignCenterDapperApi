using RealEstate_Dapper_Api.Dtos.ProductDetailDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsyncByTrue(int id);
        Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsyncByFalse(int id);
        Task<List<ResultProductWithCategoryDto>> GetResultProductWithCategoryDtoAsync();

        Task ProductDealOfTheDayStatusChangeToTrue(int id);
        Task ProductDealOfTheDayStatusChangeToFalse(int id);
        Task<List<ResultProductWithCategoryDto>> GetLast5ProductAsync();

        Task CreateProduct(CreateProductDto createProductDto);
        Task<GetProductByProductIdDto> GetProductByProductIdAsync(int id);
        Task<ResultGetProductDetailByIdDto> GetProductDetailByProductIdDAsync(int id);
    }
}
