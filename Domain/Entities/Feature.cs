using CrossCutting.Enums;

namespace Domain.Entities
{
    public class Feature
    {
        public Feature(string name, string value, FeatureType type)
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
