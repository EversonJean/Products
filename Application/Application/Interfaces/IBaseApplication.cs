using MongoDB.Bson;

namespace Application.Application.Interfaces
{
    public interface IBaseApplication<TDocument, TDto, CreateDto>
    {
        public IList<TDocument> GetAll();
        public TDto GetById(string id);
        public TDto GetById(ObjectId id);
        public void Add(CreateDto document);
        public void Update(TDto document);
        public void Delete(string id);
        public void Delete(ObjectId id);
    }
}
