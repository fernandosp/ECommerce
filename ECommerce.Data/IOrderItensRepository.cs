using ECommerce.Domain;
using System.Collections.Generic;

namespace ECommerce.Data
{
    public interface IOrderItensRepository : IRepository<OrderItens>
    {
        OrderItens GetByOrderIdAnProductId(int OrderId, int ProductId);
        List<OrderItens> GetOrderItensByOrderId(int OrderId);
    }
}
