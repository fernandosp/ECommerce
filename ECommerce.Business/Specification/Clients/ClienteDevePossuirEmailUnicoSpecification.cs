using DomainValidation.Interfaces.Specification;
using ECommerce.Data;
using ECommerce.Domain;

namespace ECommerce.Business.Valdations.Clients
{
    public class ClienteDevePossuirEmailUnicoSpecification : ISpecification<Client>
    {
        private readonly IClientRepository _clienteRepository;

        public ClienteDevePossuirEmailUnicoSpecification(IClientRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public bool IsSatisfiedBy(Client cliente)
        {
            return _clienteRepository.GetByEmail(cliente.Email) == null;
        }
    }
}