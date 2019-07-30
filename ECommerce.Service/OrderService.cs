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

        public List<Order> Get()
        {
            return _orderBusiness.GetAllOrders();
        }

        public Order GetById(int id)
        {
            return _orderBusiness.GetOrderById(id);
        }

        public List<Order> GetOrdersAproved()
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrdersNotAproved()
        {
            throw new NotImplementedException();
        }

        public void SendOrder(Order order)
        {
            _orderBusiness.Add(order);
        }
    }
}
