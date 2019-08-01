using System;
using System.Collections.Generic;

namespace ECommerce.Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity obj);
        TEntity GetById(int id);
        List<TEntity> GetAll();
    }
}
