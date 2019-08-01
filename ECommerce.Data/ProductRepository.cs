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
            var sql = "Insert Into Product (Name, Value, Quantity, IdProductType) Values(@Name, @Value, @Quantity, @IdProductType)";
           return _connection.Query<Product>(sql, obj).Single();
        }
        public override List<Product> GetAll()
        {
            string sql = "SELECT * FROM PRODUCT AS P INNER JOIN ProductType AS PT ON P.IdProductType = PT.ID;";
                        
                var products = _connection.Query<Product, ProductType, Product>(
                        sql,
                        (Product, ProductType) =>
                        {
                            Product.ProductType = ProductType;
                            return Product;
                        },
                        splitOn: "IdProductType")
                    .Distinct()
                    .ToList();

            return products;
        }

        public Product GetByName(string nome)
        {
            var sql = $@"Select * from Product where nome like '%{nome}%' ";
            return _connection.Query<Product>(sql).Single();
        }

        public override Product GetById(int id)
        {
            string sql = $"select * from product where id = {id}";

            return _connection.Query<Product>(sql).SingleOrDefault();
        }

        public void AlterQuantityAvailable(int quantity, int produtId)
        {
            string sql = $"update product set = {quantity} where Id = {produtId}";
        }
    }
}
