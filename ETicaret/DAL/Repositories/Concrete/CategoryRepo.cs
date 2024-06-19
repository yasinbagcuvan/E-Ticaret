﻿using DAL.Context;
using DAL.Repositories.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Concrete
{
    public class CategoryRepo : Repo<Category>
    {
        public CategoryRepo(ETicaretDbContext context) : base(context)
        {
        }
    }
}