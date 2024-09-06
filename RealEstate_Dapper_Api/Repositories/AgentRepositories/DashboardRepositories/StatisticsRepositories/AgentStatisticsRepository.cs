using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.AgentRepositories.DashboardRepositories.StatisticsRepositories
{
    public class AgentStatisticsRepository : IAgentStatisticsRepository
    {
        private readonly Context _context;

        public AgentStatisticsRepository(Context context)
        {
            _context = context;
        }
        public int AllProductCount()
        {
            string query = @"select * from Product";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int ProductCountByEmployeeId(int id)
        {
            string query = @"select * from Product where EmployeeId=@employeeId";
            var paremeters = new DynamicParameters();
            paremeters.Add("@employeeId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query,paremeters);
                return values;
            }
        }

        public int ProductCountByStatusFalse(int id)
        {
            string query = @"select * from Product where EmployeeId=@employeeId and ProductStatus=0";
            var paremeters = new DynamicParameters();
            paremeters.Add("@employeeId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query, paremeters);
                return values;
            }
        }

        public int ProductCountByStatusTrue(int id)
        {
            string query = @"select * from Product where EmployeeId=@employeeId and ProductStatus=1";
            var paremeters = new DynamicParameters();
            paremeters.Add("@employeeId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query, paremeters);
                return values;
            }
        }
    }
}
