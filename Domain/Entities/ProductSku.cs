using CrossCutting.Enums;

namespace Domain.Entities
{
    public class ProductSku
    {
        public ProductSku(ProductSkuStatus status, decimal priceFrom, decimal priceFor, string image, IList<Feature> features)
        {
            Status= status;
            PriceFrom = priceFrom;
            PriceFor = priceFor;
            Image= image;
            Features = features;
        }

        public ProductSkuStatus Status { get; set; }
        public decimal PriceFrom { get; set; }
        public decimal PriceFor { get; set; }
        public string Image { get; set; }

        public ICollection<Feature> Features { get; set; }
    }
}
