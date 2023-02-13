using Application.Application.Interfaces;
using AutoMapper;
using Domain.Entities.Base;
using Domain.Interfaces.Services;
using MongoDB.Bson;

namespace Application.Application
{
    public abstract class BaseApplication<TDocument, Dto, CreateDto> : IBaseApplication<TDocument, Dto, CreateDto> where TDocument : Document
    {
        protected readonly IMapper _mapper;
        protected readonly IBaseService<TDocument> _service;

        public BaseApplication(IMapper mapper, IBaseService<TDocument> service)
        {
            _service = service;
            _mapper = mapper;
        }

        public IList<TDocument> GetAll()
        {
            return _service.GetAll();
        }

        public Dto GetById(ObjectId id)
        {
            var document = _service.GetById(id);

            var documentDto = _mapper.Map<Dto>(document);

            return documentDto;
        }

        public Dto GetById(string id)
        {
            var document = _service.GetById(ObjectId.Parse(id));

            var documentDto = _mapper.Map<Dto>(document);

            return documentDto;
        }

        public void Add(CreateDto document)
        {
            var documentDb = _mapper.Map<TDocument>(document);

            _service.Add(documentDb);
        }

        public void Update(Dto document)
        {
            var documentDb = _mapper.Map<TDocument>(document);

            _service.Update(documentDb);
        }

        public void Delete(string id)
        {
            _service.Delete(ObjectId.Parse(id));
        }

        public void Delete(ObjectId id)
        {
            _service.Delete(id);
        }
    }
}
