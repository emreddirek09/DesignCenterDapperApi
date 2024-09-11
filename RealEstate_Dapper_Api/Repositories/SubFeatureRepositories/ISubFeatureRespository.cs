using RealEstate_Dapper_Api.Dtos.ResultSubFeatureDto;

namespace RealEstate_Dapper_Api.Repositories.SubFeatureRepositories
{
    public interface ISubFeatureRespository
    {
        Task<List<ResultSubFeatureDto>> GetAllSubFeatureAsync();
    }
}
