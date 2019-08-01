using Dapper;
using ECommerce.Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Data
{
    public class ProductTypeRepository : Repository<ProductType>, IProductTypeRepository
    {
        public ProductTypeRepository(IConfiguration config) : base(config)
        {
                
        }
        public override ProductType Add(ProductType obj)
        {
            var sql = "Insert Into ProductType (Name) Values(@name)";
            return _connection.Query<ProductType>(sql, obj).Single();
        }
    }
}
