using AutoMapper;
using AutoMapper.EquivalencyExpression;
using AutoMapper.Extensions.ExpressionMapping;
using DAL.Repositories.Concrete;
using DAL.Services.Abstract;
using DAL.Services.Profiles;
using DTOs;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services.Concrete
{
    public class ProductService : Service<Product, ProductDto>
    {
        public ProductService(ProductRepo repo) : base(repo)
        {
            MapperConfiguration _config = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping().AddCollectionMappers();
                cfg.AddProfile<ProductProfile>();
            });

            base._mapper = _config.CreateMapper();
        }
    }
}
