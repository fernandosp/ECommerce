using DomainValidation.Validation;
using ECommerce.Business.Valdations.Clients;
using ECommerce.Data;
using ECommerce.Domain;

namespace ECommerce.Business.Validations
{
    public class Validator
    {
        public ValidationResult ValidationResult { get; set; }
        private readonly IClientRepository _clientRepository;


        public Validator(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public bool IsValid(Client client)
        {
            ValidationResult = new ClientIsValidToCreateValidation(_clientRepository).Validate(client);
            return ValidationResult.IsValid;
        }

    }
}
