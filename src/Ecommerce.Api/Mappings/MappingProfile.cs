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
                .ForMember(x => x.Products, map => map.Ignore());

            CreateMap<Category, CategoryDto>();
              

        }
    }
}
