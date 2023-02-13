using Domain.Entities.Base;
using Domain.Interfaces.Repositories;
using Infrastructure.Database;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public class BaseRepository<TDocument> : IBaseRepository<TDocument> where TDocument : Document
    {
        protected readonly IMongoCollection<TDocument> Collection;

        public BaseRepository(IMongoDatabase database)
        {
            Collection = MongoDbConfig.GetCollection<TDocument>(database);
        }

        public TDocument GetById(ObjectId id)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, id);
            return Collection.Find(filter).SingleOrDefault();
        }

        public void Add(TDocument document)
        {
            Collection.InsertOne(document);
        }

        public void Update(TDocument document)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, document.Id);
            Collection.FindOneAndReplace(filter, document);
        }

        public void Delete(ObjectId id)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, id);
            Collection.FindOneAndDelete(filter);
        }

        public IList<TDocument> GetAll()
        {
            var documents = Collection.Find(Builders<TDocument>.Filter.Empty).ToList();

            return documents;
        }
    }
}
