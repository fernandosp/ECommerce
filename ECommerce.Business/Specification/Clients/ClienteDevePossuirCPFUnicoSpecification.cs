using DomainValidation.Interfaces.Specification;
using ECommerce.Data;
using ECommerce.Domain;

namespace ECommerce.Business.Specifications.Clients
{
    public class ClienteDevePossuirCPFUnicoSpecification : ISpecification<Client>
    {
        private readonly IClientRepository _clientRepository;

        public ClienteDevePossuirCPFUnicoSpecification(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public bool IsSatisfiedBy(Client client)
        {
            return _clientRepository.GetByCPF(client.CPF) == null;
        }
    }
}