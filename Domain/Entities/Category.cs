namespace Domain.Entities
{
    public class Category
    {
        public Category(string name, string description, SubCategory subCategory)
        {
            Name = name;
            Description = description;
            SubCategory = subCategory;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public SubCategory SubCategory { get; set; }
    }
}
