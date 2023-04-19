using GeekShooping.ProductApi.Model.Base;

namespace GeekShooping.ProductApi.Entities
{
    public sealed class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}