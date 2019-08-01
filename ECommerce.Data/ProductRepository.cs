using Dapper;
using Dapper.Contrib.Extensions;
using ECommerce.Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Data
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(IConfiguration config) : base(config)
        {

        }
        public override Product Add(Product obj)
        {
            return base.Add(obj);
        }

        public override List<Product> GetAll()
        {
            using (var conn = ConnectionFactory.GetConnection(_config))
            {
                try
                {
                    var sql = "SELECT * FROM PRODUCT AS P INNER JOIN ProductType AS PT ON P.ProductType = PT.ID;";

                    var products = conn.Query<Product, ProductType, Product>(
                      sql,
                      (Product, ProductType) =>
                      {
                          Product.ProductType = ProductType;
                          return Product;
                      },
                      splitOn: "ProductType")
                  .Distinct()
                  .ToList();

                    return products;
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

        public Product GetByName(string nome)
        {
            var sql = $@"Select * from Product where nome like '%{nome}%' ";
            return base.Query(sql);
        }

        public override Product GetById(int id)
        {
            string sql = $"select * from product where id = {id}";

            return base.Query(sql);
        }

        public void AlterQuantityAvailable(int quantity, int produtId)
        {
            string sql = $"update product set Quantity = {quantity} where Id = {produtId}";

            base.Query(sql);
        }
    }
}
