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
            var sql = $@"Select * from Client where CPF in  @CPF; ";
            return _connection.Query<Client>(sql, new { CPF = new[] { cpf } }).FirstOrDefault();
        }

        public override Client Add(Client obj)
        {
            var id = _connection.Execute("Insert Into Client (Name, Email, CPF) Values(@name, @email, @cpf) ", obj);
            return obj;
        }

        public Client GetByEmail(string email)
        {
            var sql = $@"Select * from Client where EMAIL in  @EMAIL; ";
            return _connection.Query<Client>(sql, new { EMAIL = new[] { email } }).FirstOrDefault();
        }
    }
}
