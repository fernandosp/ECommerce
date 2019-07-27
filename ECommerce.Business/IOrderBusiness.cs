using ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Business
{
    public interface IOrderBusiness
    {
        Order Add(Order order);
        List<Order> GetAllOrders();
        Order GetOrderById(int id);
    }
}
