using ECommerce.Domain;
using System;
using System.Collections.Generic;

namespace ECommerce.Service
{
    public interface IOrderService
    {
        List<Order> GetOrdersAproved();
        List<Order> GetOrdersNoAproved();
        Order SendOrder();

    }
}
