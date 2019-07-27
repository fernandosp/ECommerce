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
        public void Add(OrderItens obj)
        {
            _connection.Execute("Insert Into OrderItens (product, quantity) Values(@product, @quantity)", obj);
        }

        public List<OrderItens> GetAll()
        {
            return _connection.Query<OrderItens>($@"Select * from Order").ToList();
        }
    }
}
