using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Business;
using ECommerce.Domain;

namespace ECommerce.Service
{
    public class ClientService : IClientService
    {
        private readonly IClientBusiness _business;
        public ClientService(IClientBusiness business)
        {
            _business = business;
        }

        public void Add(Client client)
        {
            _business.Add(client);
        }

        public List<Client> GetAll()
        {
            throw new NotImplementedException();
        }

        public Client GetByCPF()
        {
            throw new NotImplementedException();
        }
    }
}
