namespace Application.Dto
{
    public class CategoryDto
    {
        public CategoryDto(string name, string description, SubCategoryDto subCategory)
        {
            Name = name;
            Description = description;
            SubCategory = subCategory;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public SubCategoryDto SubCategory { get; set; }
    }
}
