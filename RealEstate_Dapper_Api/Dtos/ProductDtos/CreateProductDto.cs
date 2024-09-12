namespace RealEstate_Dapper_Api.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string Title { get; set; }
        public int Price { get; set; }
        public string City { get; set; }
        public string Disctrict { get; set; }
        public string CoverImage { get; set; }
        public string Addresss { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public bool DealOfTheDay { get; set; }
        public DateTime Date { get; set; }
        public bool ProductStatus { get; set; }
        public int ProductCategory { get; set; }
        public int EmployeeID { get; set; }
        public string SlugUrl { get; set; }
    }
}
