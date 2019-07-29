using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Business;
using ECommerce.Domain;

namespace ECommerce.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderBusiness _orderBusiness;
        public OrderService(IOrderBusiness orderBusiness)
        {
            _orderBusiness = orderBusiness;
        }
        public List<Order> GetOrdersAproved()
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrdersNotAproved()
        {
            throw new NotImplementedException();
        }

        public Order SendOrder()
        {
            throw new NotImplementedException();
        }
    }
}
