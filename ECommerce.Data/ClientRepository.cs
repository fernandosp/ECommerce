using Dapper;
using Dapper.Contrib.Extensions;
using ECommerce.Domain;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.Data
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(IConfiguration config) : base(config)
        {

        }

        public Client GetByCPF(string cpf)
        {
            return _connection.Query<Client>($@"Select * from Client where CPF like '%{cpf}%' ").Single();
        }

        public override Client Add(Client obj)
        {
            var id = _connection.Execute("Insert Into Client (Name, Email, CPF) Values(@name, @email, @cpf) ", obj);
            return obj;
        }

        public Client GetByEmail(string email)
        {
            return _connection.Query<Client>($@"Select * from Client where EMAIL like '%{email}%' ").Single();
        }
    }
}
