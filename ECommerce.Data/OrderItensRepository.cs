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
           return _connection.Query<OrderItens>("Insert Into OrderItens (product, quantity) Values(@product, @quantity)", obj).Single();
        }

        public override List<OrderItens> GetAll()
        {
            string sql = "SELECT * FROM OrderItens AS OI INNER JOIN Product AS P ON OI.Id_Product = P.ID;";

            var orderItens = _connection.Query<OrderItens, Product, OrderItens>(
                sql, (orderitens, product) =>
                {
                    orderitens.Products = product;
                    return orderitens;
                },
                splitOn: "Id_Product").Distinct().ToList();

            return orderItens;
        }

        public OrderItens GetByOrderIdAnProductId(int OrderId, int ProductId)
        {
            string sql = $"select * from OrderItens where Id_Order = {OrderId} and Id_Product = {ProductId}";

            return _connection.Query<OrderItens>(sql).FirstOrDefault();
        }

        public List<OrderItens> GetOrderItensByOrderId(int OrderId)
        {
            string sql = $"select * from OrderItens where Id_Order = {OrderId}";

            return _connection.Query<OrderItens>(sql).ToList();
        }

        public void AlterQuantity(int quantity, int orderItemId)
        {
            string sql = $"update OrderItens set Quantity = {quantity} where Id = {orderItemId} ";

            _connection.Query<OrderItens>(sql);
        }


    }
}
