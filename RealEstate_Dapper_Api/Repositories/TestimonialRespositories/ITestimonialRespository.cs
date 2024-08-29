using RealEstate_Dapper_Api.Dtos.TestimonialDtos;

namespace RealEstate_Dapper_Api.Repositories.TestimonialRespositories
{
    public interface ITestimonialRespository
    {
        Task<List<ResultTestimonialDto>> GetAllTestimonialAsync();
    }
}
