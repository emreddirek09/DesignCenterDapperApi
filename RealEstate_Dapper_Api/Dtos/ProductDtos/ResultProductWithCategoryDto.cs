namespace RealEstate_Dapper_Api.Dtos.ProductDtos
{
    public class ResultProductWithCategoryDto
    {
        public int ProductID { get; set; }
        public float Price { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string Disctrict { get; set; }
        public string Address { get; set; }
        public string CategoryName { get; set; }
        public string CoverImage { get; set; }
    }
}
