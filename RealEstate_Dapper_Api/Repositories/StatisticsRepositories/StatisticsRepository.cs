using Dapper;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly Context _context;

        public StatisticsRepository(Context context)
        {
            _context = context;
        }
        public int ActiveCategoryCount()
        {
            string query = "Select COUNT(*) as count From Category Where [CategoryStatus]=1";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int ActiveEmployeeCount()
        {
            string query = "Select COUNT(*) as count From Employee Where Status=1";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }
         
        public int ApartmentCount()
        {
            string query = "Select COUNT(*) as count From Product where Title like '%Daire%'";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }
        //Select AVG(Price) as AvgSalePrice From Product where Type='Satılık'
        //Select AVG(Price) as AvgRentPrice From Product where Type='Kiralık'
        public decimal AverageProductPriceByRent()
        {
            string query = "Select AVG(Price) as AvgRentPrice From Product where Type='Kiralık'";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<decimal>(query);
                return values;
            }
        }

        public decimal AverageProductPriceBySale()
        {
            string query = "Select AVG(Price) as AvgSalePrice From Product where Type='Satılık'";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<decimal>(query);
                return values;
            }
        }

        //Select avg(RoomCount) as AvgRoomCount From ProductDetails 
        public int AverageRoomCount()
        {
            string query = "Select avg(RoomCount) as AvgRoomCount From ProductDetails ";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int CategoryCount()
        {
            string query = "Select count(*) as count From Category ";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public string CategoryNameByMaxProductCount()
        {
            string query = @"Select top(1) CategoryName,COUNT(*) as MaxCategoryName from Product inner join Category on Product.ProductCategory = Category.CategoryID Group By CategoryName Order By COUNT(*) Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public string CityNameByMaxProductCount()
        {
            string query = @"select top 1 City,Count(*) as 'product_count' from Product
Group by City order by product_count desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public int DifferentCitycount()
        {
            string query = @"select Count(Distinct(City)) as count from Product";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public string EmployeeNameByMaxProductCount()
        {
            string query = @"select top(1) Name,COUNT(*) as product_count from Product
                            inner join Employee 
                            On Product.EmployeeID = Employee.EmployeeID
                            group by Name order by product_count desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public decimal LastProductPrice()
        {
            string query = @"select top 1 Price from Product order by ProductID desc ";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<decimal>(query);
                return values;
            }
        }

        public int NewestBuildingYear()
        {
            string query = @"select top 1 BuildYear from ProductDetails order by BuildYear desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int OldestBuildingYear()
        {
            string query = @"select top 1 BuildYear from ProductDetails order by BuildYear asc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int PassiveCategoryCount()
        {
            //select Count(*) count from Category where CategoryStatus=0
            string query = @"select Count(*) count from Category where CategoryStatus=0";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int ProductCount()
        {
            string query = @"select Count(*) count from Product";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }
    }
}
