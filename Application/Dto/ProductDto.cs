namespace Application.Dto
{
    public class ProductDto
    {
        public ProductDto(string id, DateTime createdAt, string name, string description, 
            BrandDto brand, CategoryDto category, IList<ProductSkuDto> skus)
        {
            Id = id;
            CreatedAt = createdAt;
            Name = name;
            Description = description;
            Description = description;
            Category = category;
            Brand = brand;
            Skus = skus;
        }

        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public BrandDto Brand { get; set; }
        public CategoryDto Category { get; set; }
        public ICollection<ProductSkuDto> Skus { get; set; }
    }
}