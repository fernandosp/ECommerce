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
        public void Add(OrderRepository obj)
        {
           _connection.Execute("Insert Into Order (PaymentType, IsOrderAproved, Total, DateOrder) Values(@PaymentType, @IsOrderAproved, @Total, @DateOrder)", obj);
        }
        public List<OrderRepository> GetAll()
        {
            return _connection.Query<OrderRepository>($@"Select * from Order").ToList();
        }

    }
}
