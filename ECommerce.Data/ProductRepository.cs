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
            _connection.Insert(obj);
            return obj;
           //return _connection.Query<Product>("Insert Into Product (Name, Value, Quantity, ProductType) Values(@name, @value, @quantity, @productType)", obj).Single();
        }
        public override List<Product> GetAll()
        {
            string sql = "SELECT * FROM PRODUCT AS P INNER JOIN ProductType AS PT ON P.ProductType = PT.ID;";
                        
                var products = _connection.Query<Product, ProductType, Product>(
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
            //return _connection.Query<Product>($@"Select * from Product").ToList();
        }

        public Product GetByName(string nome)
        {
            var sql = $@"Select * from Product where nome like '%{nome}%' ";
            return _connection.Query<Product>(sql).Single();
        }

    }
}
