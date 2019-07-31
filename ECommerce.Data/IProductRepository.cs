using ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Data
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetByName(string name);

        void AlterQuantityAvailable(int quantity, int produtId);

    }
}
