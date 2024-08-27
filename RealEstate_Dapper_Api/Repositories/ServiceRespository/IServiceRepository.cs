
using RealEstate_Dapper_Api.Dtos.ServiceTos;

namespace RealEstate_Dapper_Api.Repositories.ServiceRespository
{
    public interface IServiceRepository
    {
        Task<List<ResultServiceDto>> GetAllServiceAsync();
        void CreateService(CreateServiceDto createServiceDto);
        void DeleteService(int id);
        void UpdateService(UpdateServiceDto updateServiceDto);
        Task<GetByIdServiceDto> GetService(int id);
    }
}
