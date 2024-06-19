using BLL.Abstract;
using DAL.Services.Concrete;
using DTOs;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BLL.Concrete
{
    public class ProductManager : Manager<ProductDto, ProductViewModel, Product>
    {
        public ProductManager(ProductService service) : base(service)
        {
        }
    }
}
