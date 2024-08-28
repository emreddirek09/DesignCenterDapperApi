using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepositories
{
    public interface IPopularLocationRespository
    {
        Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync(); 
    }
}
