using ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Business
{
    public interface IOrderBusiness
    {
        void Add(Order order);
        List<Order> GetAllOrders();
        Order GetOrderById(int id);
    }
}
