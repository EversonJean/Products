namespace Application.Dto
{
    public class BrandDto
    {
        public BrandDto(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
