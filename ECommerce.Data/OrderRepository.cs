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
        
        public override List<Order> GetAll()
        {
            using (_connection)
            {
                return _connection.Query<Order, Client, Order>(
                        $@"Select * from
                        Orders O  inner join Client C 
                        on O.Id_Client = C.Id ",
                        map: (Order, Client) =>
                        {
                            Order.Client = Client;
                            return Order;
                        },
                        splitOn: "Id,Id").ToList();

            }
        }

        public override Order GetById(int id)
        {
            //return _connection.Query<Order>($@"Select * from
            //                                Orders O  inner join Client C 
            //                                on O.Id_Client = C.Id where O.Id = {id}").SingleOrDefault();

            using (_connection)
            {
                return _connection.Query<Order, Client, Order>(
                        $@"Select * from
                        Orders O  inner join Client C 
                        on O.Id_Client = C.Id where O.Id = {id}",
                        map: (Order, Client) =>
                        {
                            Order.Client = Client;
                            return Order;
                        },
                        splitOn: "Id,Id").SingleOrDefault();
                
            }


        }

        public void Add(Order obj)
        {
            _connection.Query<Order>($"Insert Into Orders (Id_Client, PaymentType, OrderStatus, Total, DateOrder) Values('" + obj.Client.Id + "', @PaymentType, 'ABERTA', 0, " + DateTime.Now + ")", obj);
        }
    }
}
