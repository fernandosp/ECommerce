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
            return base.Query(sql, new { CPF = new[] { cpf } });
        }

        public override Client Add(Client obj)
        {
            string sql = $"Insert Into Client (Name, Email, CPF) Values({obj.Name}, {obj.Email}, {obj.CPF}) ";

            return base.Query(sql);
        }

        public Client GetByEmail(string email)
        {
            var sql = $@"Select * from Client where EMAIL in  @EMAIL; ";
            return base.Query(sql, new { EMAIL = new[] { email } });
        }
    }
}
