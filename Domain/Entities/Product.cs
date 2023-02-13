using Domain.Attributes;
using Domain.Entities.Base;

namespace Domain.Entities
{
    [MongoDBCollection("products")]
    public class Product : Document
    {
        public Product(string name, string description, Brand brand, Category category, IList<ProductSku> skus)
        {
            Name = name;
            Description= description;
            Description = description;
            Category = category;
            Brand = brand;
            Skus = skus;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public Brand Brand { get; set; }
        public Category Category { get; set; }
        public ICollection<ProductSku> Skus { get; set; }
    }
}
