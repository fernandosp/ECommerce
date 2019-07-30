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
           return _connection.Query<Product>("Insert Into Product (Name, Value, Quantity, ProductType) Values(@name, @value, @quantity, @productType)", obj).Single();
        }
        public override List<Product> GetAll()
        {
            return _connection.Query<Product>($@"Select * from Product").ToList();
        }

        public Product GetByName(string nome)
        {
            return _connection.Query<Product>($@"Select * from Product where nome like '%{nome}%' ").Single();
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
