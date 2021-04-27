using Iqt.Inventory.Entities;

namespace Products.Base.Entities
{
    /// <summary>
    /// The brand of the product
    /// </summary>
    public class ProductBrand
    {
        public ProductBrand(string productId, string brandId)
        {
            ProductId = productId;
            BrandId = brandId;
        }
        
        public string ProductId { get; set; }
        public Product Product { get; set; }

        public string BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}