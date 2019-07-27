using DomainValidation.Interfaces.Specification;
using ECommerce.Business.Valdations.Documents;
using ECommerce.Domain;

namespace ECommerce.Business.Valdations.Clients
{
    public class ClienteDeveTerCpfValidoSpecification : ISpecification<Client>
    {
        public bool IsSatisfiedBy(Client client)
        {
            return CPFValidation.Validar(client.CPF);
        }
    }
}