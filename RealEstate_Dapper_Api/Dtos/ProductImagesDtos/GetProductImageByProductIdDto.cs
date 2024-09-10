  namespace RealEstate_Dapper_Api.Dtos.ProductImagesDtos
{
    public class GetProductImageByProductIdDto
    {
        public int ProductImagesId { get; set; }
        public int ProductId { get; set; }
        public string ImageUrl { get; set; }
    }
}
