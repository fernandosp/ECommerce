using ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Service
{
    public interface IClientService
    {
        List<Client> GetAll();
        Client GetByCPF();
        void Add(Client client);
    }
}
