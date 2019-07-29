using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Service
{
    public interface IServiceBase<T>
    {
        List<T> GetAll();
        void Add(T obj);
    }
}
