namespace RealEstate_Dapper_UI.Dtos.ProductDtos
{
    public class ResultLast3ProductWithCategoryDto
    {
        public int ProductID { get; set; }
        public float Price { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string Disctrict { get; set; }
        public string Description { get; set; }

        public string Address { get; set; }
        public string CategoryName { get; set; }
        public string CoverImage { get; set; }
        public string Type { get; set; }
        public bool DealOfTheDay { get; set; }
        public DateTime Date { get; set; }
        public string SlugUrl { get; set; }

    }
}
