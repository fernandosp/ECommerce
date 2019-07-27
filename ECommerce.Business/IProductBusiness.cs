using ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Business
{
    public interface IProductBusiness
    {
        void Add(Product product);
        Product GetProductById(int id);
        List<Product> GetAll();
    }
}
