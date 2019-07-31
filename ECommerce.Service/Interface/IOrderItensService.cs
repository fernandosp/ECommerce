using ECommerce.Business;
using ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Service
{
    public interface IOrderItensService
    {
        List<OrderItens> GetAll();
        void Add(OrderItens orderItens, int orderId);
    }
}
