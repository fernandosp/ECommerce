using Dapper;
using ECommerce.Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Data
{
    public class OrderItensRepository : Repository<OrderItens>, IOrderItensRepository
    {
        public OrderItensRepository(IConfiguration config) : base(config)
        {

        }
        
        public List<OrderItens> GetAll()
        {
            return _connection.Query<OrderItens>($@"Select * from Order").ToList();
        }
        public OrderItens Add(OrderItens obj, int IdOrder)
        {
            return _connection.Query<OrderItens>("Insert Into OrderItens (Id_Order, Id_Product, Quantity) Values('" + IdOrder + "', '" + obj.Products.Id + "', @Quantity)", obj).Single();
        }
    }
}
