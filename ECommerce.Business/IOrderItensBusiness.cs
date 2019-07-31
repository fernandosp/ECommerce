using ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Business
{
    public interface IOrderItensBusiness
    {
        OrderItens Add(OrderItens orderItens, int id_order);
        List<OrderItens> GetAll();
    }
}
