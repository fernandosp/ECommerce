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
            return _connection.Query<ProductType>("Insert Into ProductType (Name) Values(@name)", obj).Single();
        }
    }
}
