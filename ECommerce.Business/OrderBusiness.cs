using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Data;
using ECommerce.Domain;

namespace ECommerce.Business
{
    public class OrderBusiness : IOrderBusiness
    {
        private readonly IOrderRepository _orderRepository;
        public OrderBusiness(IOrderRepository iOrderRepository)
        {
            _orderRepository = iOrderRepository;
        }

        
        public void Add(Order order)
        {
            _orderRepository.Add(order);
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepository.GetAll();
        }

        public Order GetOrderById(int id)
        {
            return _orderRepository.GetById(id);
        }
    }
}
