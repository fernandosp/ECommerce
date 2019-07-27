using Dapper;
using ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Data
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public void Add(ProductRepository obj)
        {
            _connection.Execute("Insert Into Product (Name, Value, Quantity, ProductType) Values(@name, @value, @quantity, @productType)", obj);
        }
        public List<ProductRepository> GetAll()
        {
            return _connection.Query<ProductRepository>($@"Select * from Product").ToList();
        }

    }
}
