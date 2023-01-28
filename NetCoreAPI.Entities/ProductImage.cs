namespace NetCoreAPI.Entities
{
    public partial class ProductImage
    {
        public int ProductImageId { get; set; }
        public int ProductId { get; set; }
        public string ProductImageName { get; set; }
        public string ImagePath { get; set; }
        public string Decription { get; set; }
        
    }
}

