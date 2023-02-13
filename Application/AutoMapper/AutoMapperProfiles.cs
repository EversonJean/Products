using AutoMapper;
using Domain.Entities;
using Application.Dto;
using MongoDB.Bson;

namespace Application.AutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Product, ProductDto>().ReverseMap()
                .ForMember(dest => dest.Id, act => act.MapFrom(p => ObjectId.Parse(p.Id)));

            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<ProductSku, ProductSkuDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<SubCategory, SubCategoryDto>().ReverseMap();
            CreateMap<Feature, FeatureDto>().ReverseMap();
            CreateMap<Brand, BrandDto>().ReverseMap();
        }
    }
}
