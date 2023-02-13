using MongoDB.Bson;

namespace Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TDocument>
    {
        public IList<TDocument> GetAll();
        public TDocument GetById(ObjectId id);
        public void Add(TDocument document);
        public void Update(TDocument document);
        public void Delete(ObjectId id);
    }
}
