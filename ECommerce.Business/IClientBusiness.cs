using ECommerce.Domain;
using System.Collections.Generic;

namespace ECommerce.Business
{
    public interface IClientBusiness
    {
        Client Add(Client client);
        Client GetByCPF(string cpf);
        List<Client> GetAll();
        Client GetByEmail(string email);
    }
}
