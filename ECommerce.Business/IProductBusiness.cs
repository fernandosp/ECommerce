using ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Business
{
    public interface IProductBusiness
    {
        Product Add(Product product);
        Product GetByName(string name);
        List<Product> GetAll();

    }
}
