using Dapper;
using ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Data
{
    public class OrderItensRepository : Repository<OrderItens>, IOrderItensRepository
    {
        public void Add(OrderItensRepository obj)
        {
            _connection.Execute("Insert Into OrderItens (product, quantity) Values(@product, @quantity)", obj);
        }
        public List<OrderItensRepository> GetAll()
        {
            return _connection.Query<OrderItensRepository>($@"Select * from Order").ToList();
        }
    }
}
