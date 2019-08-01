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
        public override OrderItens Add(OrderItens obj)
        {
            string sql = $"Insert Into OrderItens (product, quantity) Values({obj.Products.Id}, {obj.Quantity})";

            return base.Query(sql);
        }

        public override List<OrderItens> GetAll()
        {
            
            using (var conn = ConnectionFactory.GetConnection(_config))
            {
                try
                {
                    string sql = "SELECT * FROM OrderItens AS OI INNER JOIN Product AS P ON OI.Id_Product = P.ID;";

                    var orderItens = conn.Query<OrderItens, Product, OrderItens>(
                        sql, (orderitens, product) =>
                        {
                            orderitens.Products = product;
                            return orderitens;
                        },
                        splitOn: "Id_Product").Distinct().ToList();

                    return orderItens;

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

        public OrderItens GetByOrderIdAnProductId(int OrderId, int ProductId)
        {
            string sql = $"select * from OrderItens where Id_Order = {OrderId} and Id_Product = {ProductId}";

            return base.Query(sql);
        }

        public List<OrderItens> GetOrderItensByOrderId(int OrderId)
        {
            string sql = $"select * from OrderItens where Id_Order = {OrderId}";

            return base.QueryAll(sql);
        }

        public void AlterQuantity(int quantity, int orderItemId)
        {
            string sql = $"update OrderItens set Quantity = {quantity} where Id = {orderItemId} ";

            base.Query(sql);
        }

        public void Add(OrderItens orderItens, int orderId)
        {
            string sql = $"Insert into OrderItens (Id_Order, Id_Product, Quantity) values ({orderId},{orderItens.Products.Id},{orderItens.Quantity})";

             base.Query(sql);
        }

    }
}
