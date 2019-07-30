using ECommerce.Domain;
using System;
using System.Collections.Generic;

namespace ECommerce.Service
{
    public interface IOrderService
    {
        List<Order> GetOrdersAproved();
        List<Order> GetOrdersNotAproved();
        void SendOrder(Order order);
        Order GetById(int id);
        List<Order> Get();
    }
}
