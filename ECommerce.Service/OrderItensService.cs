using ECommerce.Business;
using ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Service
{
    public class OrderItensService : IOrderItensService
    {
        private readonly IOrderItensBusiness _orderItensBusiness;
        public OrderItensService(IOrderItensBusiness orderItensBusiness)
        {
            _orderItensBusiness = orderItensBusiness;
        }

        public void Add(OrderItens orderItens, int orderId)
        {
            _orderItensBusiness.Add(orderItens, orderId);
        }

        public List<OrderItens> GetAll()
        {
            return _orderItensBusiness.GetAll();
        }

    }
}
