namespace Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class MongoDBCollectionAttribute : Attribute
    {
        public string CollectionName { get; }

        public MongoDBCollectionAttribute(string collectionName)
        {
            CollectionName = collectionName;
        }
    }
}
