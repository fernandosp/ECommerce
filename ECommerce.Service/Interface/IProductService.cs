using ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Service
{
    public interface IProductService : IServiceBase<Product>
    {
        Product GetByName(string obj);
    }
}
