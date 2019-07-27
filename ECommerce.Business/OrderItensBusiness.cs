using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Data;
using ECommerce.Domain;

namespace ECommerce.Business
{
    public class OrderItensBusiness : IOrderItensBusiness
    {
        private readonly IOrderItensRepository _IOrderItensRepository;
        public OrderItensBusiness(IOrderItensRepository iOrderItensRepository)
        {
            _IOrderItensRepository = iOrderItensRepository;
        }
        public OrderItens Add(OrderItens orderItens)
        {
            return _IOrderItensRepository.Add(orderItens);
        }

        public List<OrderItens> GetAll()
        {
            return _IOrderItensRepository.GetAll();
        }
    }
}
