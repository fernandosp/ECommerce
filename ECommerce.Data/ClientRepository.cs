using Dapper;
using ECommerce.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.Data
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public List<ClientRepository> GetByCPF(string cpf)
        {
            return _connection.Query<ClientRepository>($@"Select * from Client where brand like '%{cpf}%' ").ToList();
        }

        public void Add(ClientRepository obj)
        {
            _connection.Execute("Insert Into Client (Name, Email, CPF) Values(@name, @email, @cpf)", obj);
        }
    }
}
