﻿using Dapper;
using ECommerce.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.Data
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public Client GetByCPF(string cpf)
        {
            return _connection.Query<Client>($@"Select * from Client where CPF like '%{cpf}%' ").Single();
        }

        public void Add(ClientRepository obj)
        {
            _connection.Execute("Insert Into Client (Name, Email, CPF) Values(@name, @email, @cpf)", obj);
        }

        public Client GetByEmail(string email)
        {
            return _connection.Query<Client>($@"Select * from Client where EMAIL like '%{email}%' ").Single();
        }
    }
}
