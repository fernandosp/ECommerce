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
            using (var conn = ConnectionFactory.GetConnection(_config))
            {
                try
                {
                    return conn.Query<Order, Client, Order>(
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
                catch
                {
                    throw;
                }
                finally
                {
                    if (conn?.State != System.Data.ConnectionState.Closed)
                    {
                        conn?.Close();
                    }
                }
            }
            
            
        }

        public override Order GetById(int id)
        {
            //return _connection.Query<Order>($@"Select * from
            //                                Orders O  inner join Client C 
            //                                on O.Id_Client = C.Id where O.Id = {id}").SingleOrDefault();


            using (var conn = ConnectionFactory.GetConnection(_config))
            {
                try
                {
                    return conn.Query<Order, Client, Order>(
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
                catch
                {
                    throw;
                }
                finally
                {
                    if (conn?.State != System.Data.ConnectionState.Closed)
                    {
                        conn?.Close();
                    }
                }
            }

            


        }

        public void Add(Order obj)
        {
            string sql = $"Insert Into Orders (Id_Client, PaymentType, OrderStatus, Total, DateOrder)" +
                $" Values(" + obj.Client_Id + ", '" + obj.PaymentType + "', 'ABERTA', 0, getdate())";

            base.Query(sql);
        }

        public void AlterTotal(decimal total, int IdOrder)
        {
            string sql = $"update Orders set total = {total} where id = {IdOrder}";

            base.Query(sql);
        }

        public Order GetOne(int id)
        {
            string sql = $"SELECT * from Orders where Id = {id}";

            return base.Query(sql);
        }
    }
}
