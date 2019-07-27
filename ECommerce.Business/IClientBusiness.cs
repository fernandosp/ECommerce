using ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Business
{
    public interface IClientBusiness
    {
        void Validar(Client client);
        void Add(Client client);
        void GetByCPF();
        void GetAll();
    }
}
