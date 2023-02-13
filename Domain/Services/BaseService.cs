using Domain.Entities.Base;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using MongoDB.Bson;

namespace Domain.Services
{
    public abstract class BaseService<TDocument> : IBaseService<TDocument> where TDocument : Document
    {
        protected readonly IBaseRepository<TDocument> _repository;

        public BaseService(IBaseRepository<TDocument> repository)
        {
            _repository = repository;
        }

        public IList<TDocument> GetAll()
        {
            return _repository.GetAll();
        }

        public void Add(TDocument document)
        {
            _repository.Add(document);
        }

        public void Delete(ObjectId id)
        {
            _repository.Delete(id);
        }

        public TDocument GetById(ObjectId id)
        {
            return _repository.GetById(id);
        }

        public void Update(TDocument document)
        {
            _repository.Update(document);
        }
    }
}
