using AutoMapper;
using DTOs;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>().ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category)).ReverseMap();
            CreateMap<Product, ProductDto>().ForMember(dest => dest.ProductImages, opt => opt.MapFrom(src => src.ProductImages)).ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<ProductImages, ProductImagesDto>().ReverseMap();

        }
    }
}
