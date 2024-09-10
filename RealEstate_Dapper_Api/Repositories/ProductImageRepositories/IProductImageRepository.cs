using RealEstate_Dapper_Api.Dtos.ProductImagesDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductImageRepositories
{
    public interface IProductImageRepository
    {
        Task<List<GetProductImageByProductIdDto>> GetProductImageByProductIdAsync(int id);
    }
}
