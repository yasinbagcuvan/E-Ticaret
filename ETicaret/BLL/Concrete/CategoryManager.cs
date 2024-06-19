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
    public class CategoryManager : Manager<CategoryDto, CategoryViewModel, Category>
    {
        public CategoryManager(CategoryService service) : base(service)
        {
        }

        //public int UserId
        //{
        //    set { base.AppUserId = value; }
        //}
    }
}
