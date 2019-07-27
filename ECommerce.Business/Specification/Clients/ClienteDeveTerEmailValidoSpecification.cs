using DomainValidation.Interfaces.Specification;
using ECommerce.Business.Valdations.Documents;
using ECommerce.Domain;

namespace ECommerce.Business.Valdations.Clients
{
    public class ClienteDeveTerEmailValidoSpecification : ISpecification<Client>
    {
        public bool IsSatisfiedBy(Client client)
        {
            return EmailValidation.Validate(client.Email);
        }
    }
}