using Dapper;
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

        public Client Add(ClientRepository obj)
        {
            return _connection.Query<Client>("Insert Into Client (Name, Email, CPF) Values(@name, @email, @cpf)", obj).Single();
        }

        public Client GetByEmail(string email)
        {
            return _connection.Query<Client>($@"Select * from Client where EMAIL like '%{email}%' ").Single();
        }
    }
}
