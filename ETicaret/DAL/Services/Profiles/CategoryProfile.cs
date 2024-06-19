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
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>().ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products)).ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
