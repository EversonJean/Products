using CrossCutting.Enums;

namespace Application.Dto
{
    public class FeatureDto
    {
        public FeatureDto(string name, string value, FeatureType type)
        {
            Name = name;
            Value = value;
            Type = type;
        }

        public string Name { get; set; }
        public string Value { get; set; }
        public FeatureType Type { get; set; }
    }
}
