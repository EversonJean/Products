using MongoDB.Bson;

namespace Domain.Interfaces.Services
{
    public interface IBaseService<TDocument>
    {
        public IList<TDocument> GetAll();
        public TDocument GetById(ObjectId id);
        public void Add(TDocument document);
        public void Update(TDocument document);
        public void Delete(ObjectId id);
    }
}
