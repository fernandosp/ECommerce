using ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Data
{
    public interface IOrderItensRepository : IRepository<OrderItens>
    {
        OrderItens Add(OrderItens obj);
    }
}
