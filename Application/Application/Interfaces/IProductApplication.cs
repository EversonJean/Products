using Application.Dto;
using Domain.Entities;

namespace Application.Application.Interfaces
{
    public interface IProductApplication : IBaseApplication<Product, ProductDto, CreateProductDto>
    {
    }
}
