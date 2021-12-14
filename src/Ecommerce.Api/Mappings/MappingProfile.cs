using AutoMapper;
using Eccomerce.Domain.Entities;
using Ecommerce.Api.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Mappings
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<CategoryDto, Category>()
                .ForMember(x => x.Id, map => map.Ignore())
                .ForMember(x => x.RegisterDate, map => map.Ignore())
                .ForMember(x => x.Products, map => map.Ignore())
                .ForMember(x => x.Slug, map => map.Ignore());

            CreateMap<Category, CategoryDto>();



            CreateMap<ProductDto, Product>()
                .ForMember(x => x.Id, map => map.Ignore())
                .ForMember(x => x.RegisterDate, map => map.Ignore())
                .ForMember(x => x.EntityStatus, map => map.Ignore())
                .ForMember(x => x.DeleteDate, map => map.Ignore())
                .ForMember(x => x.UpdateDate, map => map.Ignore())
                .ForMember(x => x.OrderProducts, map => map.Ignore())
                .ForMember(x => x.Category, map => map.Ignore());



            CreateMap<Product, ProductDto>();


        }
    }
}
