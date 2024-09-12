namespace RealEstate_Dapper_Api.Dtos.ProductDetailDtos
{
    public class ResultGetProductDetailByIdDto
    {
        public int ProductID { get; set; }
        public int ProductDetailID { get; set; }
        public int ProductSize { get; set; }
        public int BedRoomCount { get; set; }
        public int BathCount { get; set; }
        public int RoomCount { get; set; }
        public int GarageSize { get; set; }
        public string BuildYear { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public string VideoUrl { get; set; }
        public string SlugUrl { get; set; }

    }
}
