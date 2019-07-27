using ECommerce.Domain;

namespace ECommerce.Data
{
    public interface IClientRepository : IRepository<Client>
    {
        Client GetByEmail(string email);
        Client GetByCPF(string email);
    }
}
