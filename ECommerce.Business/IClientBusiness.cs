using ECommerce.Domain;
using System.Collections.Generic;

namespace ECommerce.Business
{
    public interface IClientBusiness
    {
        void Validar(Client client);
        Client Add(Client client);
        Client GetByCPF(string cpf);
        List<Client> GetAll();
    }
}
