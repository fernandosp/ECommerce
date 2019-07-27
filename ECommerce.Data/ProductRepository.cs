using Dapper;
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
            return _connection.Query<Product>("Insert Into Product (Name, Value, Quantity, ProductType) Values(@name, @value, @quantity, '" + obj.ProductType + "')", obj).Single();
        }

        public List<Product> GetAll()
        {
            return _connection.Query<Product>($@"Select * from Product").ToList();
        }

    }
}
