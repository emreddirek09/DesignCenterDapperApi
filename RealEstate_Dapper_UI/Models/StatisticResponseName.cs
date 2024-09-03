namespace RealEstate_Dapper_UI.Models
{
    public class StatisticResponseValueName
    {
        public string[] namesEng = ["CategoryCount", "ActiveCategoryCount", "PassiveCategoryCount", "ProductCount", "ApartmentCount", "EmployeeNameByMaxProductCount", "CategoryNameByMaxProductCount", "AverageProductPriceByRent", "AverageProductPriceBySale", "CityNameByMaxProductCount", "DifferentCitycount", "LastProductPrice", "NewestBuildingYear", "OldestBuildingYear", "AverageRoomCount", "ActiveEmployeeCount"];
       
        public string[] namesTr = ["Kategori Sayısı", "Aktif Kategori Sayısı", "Pasif Kategori Sayısı", "Ürün Sayısı", "Daire Sayısı", "Maksimum Ürün Sayısına Göre Çalışan Adı", "Maksimum Ürün Sayısına Göre Kategori Adı", "Kiraya Göre Ortalama Ürün Fiyatı", "Satışa Göre Ortalama Ürün Fiyatı", "Maksimum Ürün Sayısına Göre Şehir Adı", "Farklı Şehir Sayısı", "Son Ürün Fiyatı", "En Yeni Bina Yılı", "En Eski Bina Yılı", "Ortalama Oda Sayısı", "Aktif Çalışan Sayısı"];
    }

    public class StatisticResponseValue
    {
        public Dictionary<string, string> pairs = new Dictionary<string, string>();
    }



}
