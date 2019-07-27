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
        public void Add(Product obj)
        {
            _connection.Execute("Insert Into Product (Name, Value, Quantity, ProductType) Values(@name, @value, @quantity, @productType)", obj);
        }
        public List<Product> GetAll()
        {
            return _connection.Query<Product>($@"Select * from Product").ToList();
        }

        public Client GetByName(string nome)
        {
            return _connection.Query<Client>($@"Select * from Product where nome like '%{nome}%' ").Single();
        }

    }
}
