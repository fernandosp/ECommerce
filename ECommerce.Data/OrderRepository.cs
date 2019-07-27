using Dapper;
using ECommerce.Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Data
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(IConfiguration config) : base(config)
        {

        }
        
        public List<OrderRepository> GetAll()
        {
            return _connection.Query<OrderRepository>($@"Select * from Orders").ToList();
        }
        public Order Add(Order obj)
        {
            return _connection.Query<Order>("Insert Into Orders (Id_Client, PaymentType, OrderStatus, Total, DateOrder) Values('" + obj.Client.Id + "', @PaymentType, @OrderStatus, @Total, @DateOrder)", obj).Single();
        }
    }
}
