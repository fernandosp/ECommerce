using ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Service
{
    public interface IClientService
    {
        List<Client> GetAll();
        Client GetByCPF(string cpf);
        void Add(Client client);
        Client GetByEmail(string email);

    }
}
