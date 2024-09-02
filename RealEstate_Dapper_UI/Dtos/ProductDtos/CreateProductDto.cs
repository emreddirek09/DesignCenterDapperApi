namespace RealEstate_Dapper_UI.Dtos.ProductDtos
{
    public class CreateProductDto
    {
         public float price { get; set; }
        public string title { get; set; }
        public string city { get; set; }
        public string disctrict { get; set; }
        public string address { get; set; }
        public string categoryid { get; set; }
        public string coverImage { get; set; }
        public string type { get; set; }
    }
}
