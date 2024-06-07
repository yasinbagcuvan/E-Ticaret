using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Abstract
{
    public interface IRepo
    {
        public interface IRepo<TEntity> where TEntity : BaseEntity
        {
            int Add(TEntity entity);
            int Update(TEntity entity);
            int Delete(TEntity entity);
            TEntity? GetById(int id);
            Task<TEntity>? GetByIdAsync(int id);
            IEnumerable<TEntity> GetAll();
        }
    }
}
