using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Services;
using Application.Dto;
using Application.Application.Interfaces;

namespace Application.Application
{
    public class ProductApplication : BaseApplication<Product, ProductDto, CreateProductDto>, IProductApplication
    {
        public ProductApplication(IMapper mapper, IProductService service) : base(mapper, service)
        {
        }
    }
}