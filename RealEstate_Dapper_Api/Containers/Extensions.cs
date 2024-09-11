using Microsoft.Extensions.DependencyInjection;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Repositories.AgentRepositories.DashboardRepositories.LastProductRepositories;
using RealEstate_Dapper_Api.Repositories.AgentRepositories.DashboardRepositories.StatisticsRepositories;
using RealEstate_Dapper_Api.Repositories.AppUserRepositories;
using RealEstate_Dapper_Api.Repositories.BottomGridRepositories;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;
using RealEstate_Dapper_Api.Repositories.ContactRepositories;
using RealEstate_Dapper_Api.Repositories.EmployeeRepositories;
using RealEstate_Dapper_Api.Repositories.MessageRepositories;
using RealEstate_Dapper_Api.Repositories.PopularLocationRepositories;
using RealEstate_Dapper_Api.Repositories.ProductImageRepositories;
using RealEstate_Dapper_Api.Repositories.ProductRepository;
using RealEstate_Dapper_Api.Repositories.PropertyAmenityRepositories;
using RealEstate_Dapper_Api.Repositories.ServiceRespository;
using RealEstate_Dapper_Api.Repositories.StatisticsRepositories;
using RealEstate_Dapper_Api.Repositories.SubFeatureRepositories;
using RealEstate_Dapper_Api.Repositories.TestimonialRespositories;
using RealEstate_Dapper_Api.Repositories.ToDoListRepositories;
using RealEstate_Dapper_Api.Repositories.WhoWEAreRespository;

namespace RealEstate_Dapper_Api.Containers
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
           services.AddTransient<Context>();
           services.AddTransient<ICategoryRepository, CategoryRepository>();
           services.AddTransient<IProductRepository, ProductRespository>();
           services.AddTransient<IWhoWEAreDetailRespository, WhoWEAreDetailRespository>();
           services.AddTransient<IServiceRepository, ServiceRepository>();
           services.AddTransient<IBottomGridRepository, BottomGridRepository>();
           services.AddTransient<IPopularLocationRespository, PopularLocationRespository>();
           services.AddTransient<ITestimonialRespository, TestimonialRespository>();
           services.AddTransient<IEmployeeRepository, EmployeeRepository>();
           services.AddTransient<IStatisticsRepository, StatisticsRepository>();
           services.AddTransient<IContactRepository, ContactRepository>();
           services.AddTransient<IToDoListRepository, ToDoListRepository>();
           services.AddTransient<IToDoListRepository, ToDoListRepository>();
           services.AddScoped<IAgentStatisticsRepository, AgentStatisticsRepository>();
           services.AddTransient<ILast5ProductRespository, Last5ProductRespository>();
           services.AddTransient<IMessageRepository, MessageRepository>();
           services.AddTransient<IProductImageRepository, ProductImageRepository>();
           services.AddTransient<IAppUserRepository, AppUserRepository>();
           services.AddTransient<IPropertyAmenityRepository, PropertyAmenityRepository>();
           services.AddTransient<ISubFeatureRespository, SubFeatureRespository>();
        }
    }
}
