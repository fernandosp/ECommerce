using ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Data
{
    public interface IOrderRepository : IRepository<Order>
    {
        void Add(Order obj);
        void AlterTotal(decimal total, int IdOrder);
        Order GetOne(int id);

    }
}
