using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.AgentRepositories.DashboardRepositories.LastProductRepositories
{
    public interface ILast5ProductRespository
    {
        Task<List<ResultProductWithCategoryDto>> GetLast5ProductAsync(int id);

    }
}
