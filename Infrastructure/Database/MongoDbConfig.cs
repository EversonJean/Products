using Domain.Attributes;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace Infrastructure.Database
{
    public class MongoDbConfig
    {
        public static IMongoCollection<TDocument> GetCollection<TDocument>(IMongoDatabase database)
        {
            return database.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
        }

        private static string? GetCollectionName(Type documentType)
        {
            var attribute = (MongoDBCollectionAttribute?)Attribute.GetCustomAttribute(documentType, typeof(MongoDBCollectionAttribute));

            return attribute?.CollectionName;
        }

        public static void UseMongoConventions()
        {
            var pack = new ConventionPack
            {
                new CamelCaseElementNameConvention(),
            };
            ConventionRegistry.Register("Default Conventions", pack, _ => true);
        }
    }
}
