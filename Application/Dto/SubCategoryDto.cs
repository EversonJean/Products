namespace Application.Dto
{
    public class SubCategoryDto
    {
        public SubCategoryDto(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
