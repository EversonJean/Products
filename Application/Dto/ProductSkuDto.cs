using CrossCutting.Enums;

namespace Application.Dto
{
    public class ProductSkuDto
    {
        public ProductSkuDto(ProductSkuStatus status, decimal priceFrom, decimal priceFor, string image, IList<FeatureDto> features)
        {
            Status = status;
            PriceFrom = priceFrom;
            PriceFor = priceFor;
            Image = image;
            Features = features;
        }

        public ProductSkuStatus Status { get; set; }
        public decimal PriceFrom { get; set; }
        public decimal PriceFor { get; set; }
        public string Image { get; set; }

        public ICollection<FeatureDto> Features { get; set; }
    }
}
