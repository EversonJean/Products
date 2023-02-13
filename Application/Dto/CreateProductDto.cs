namespace Application.Dto
{
    public class CreateProductDto
    {
        public CreateProductDto(string name, string description,
            BrandDto brand, CategoryDto category, IList<ProductSkuDto> skus)
        {
            Name = name;
            Description = description;
            Description = description;
            Category = category;
            Brand = brand;
            Skus = skus;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public BrandDto Brand { get; set; }
        public CategoryDto Category { get; set; }
        public ICollection<ProductSkuDto> Skus { get; set; }
    }
}