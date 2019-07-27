using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Data
{
    class Client : Repository<Client>, IClientRepository
    {
        public List<Client> GetByBrand(string brand)
        {
            return _connection.Query<Client>($@"Select * from Car where brand like '%{brand}%' ").ToList();
        }

        public override void Add(Client obj)
        {
            _connection.Execute("Insert Into CAR (YEAR, BRAND, MODEL) Values(@year, @brand, @model)", obj);
        }
    }
    {
    }
}
