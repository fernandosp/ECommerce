using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Data
{
    public class Client : Repository<Client>, IClientRepository
    {
        public List<Client> GetByBrand(string name)
        {
            return _connection.Query<Client>($@"Select * from Client where brand like '%{name}%' ").ToList();
        }

        public override void Add(Client obj)
        {
            _connection.Execute("Insert Into Client (Name, Email, CPF) Values(@name, @email, @cpf)", obj);
        }
    }
}
