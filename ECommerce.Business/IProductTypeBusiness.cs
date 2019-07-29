using ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Business
{
    public interface IProductTypeBusiness
    {
        ProductType Add(ProductType productType);
        List<ProductType> GetAll();
        ProductType GetByName(string name);
    }
}
