using ECommerce.Domain;
using DomainValidation.Validation;
using ECommerce.Business.Specifications.Clients;
using ECommerce.Data;

namespace ECommerce.Business.Valdations.Clients
{
    public class ClientIsValidToCreateValidation : Validator<Client>
    {
        public ClientIsValidToCreateValidation(IClientRepository clientRepository)
        {
            var cpfDuplicado = new ClienteDevePossuirCPFUnicoSpecification(clientRepository);
            var emailDuplicado = new ClienteDevePossuirEmailUnicoSpecification(clientRepository);

            base.Add("cpfDuplicado", new Rule<Client>(cpfDuplicado, "CPF já cadastrado! Esqueceu sua senha?"));
            base.Add("emailDuplicado", new Rule<Client>(emailDuplicado, "E-mail já cadastrado! Esqueceu sua senha?"));
        }
    }
}
