using ECommerce.Business.Valdations.Clients;
using ECommerce.Business.Validations;
using ECommerce.Data;
using ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Business
{
    public class ClientBusiness : IClientBusiness
    {
        private readonly IClientRepository _iClientRepository;
        public ClientBusiness(IClientRepository iClientRepository)
        {
            iClientRepository = _iClientRepository;
        }

        public Client Add(Client cliente)
        {
            var validtor = new Validator(_iClientRepository);

            if (!validtor.IsValid(cliente))
            {
                return cliente;
            }

            validtor.ValidationResult = new ClientIsValidToCreateValidation(_iClientRepository).Validate(cliente);
            if (!validtor.ValidationResult.IsValid)
            {
                return cliente;
            }

            validtor.ValidationResult.Message = "Cliente cadastrado com sucesso :)";
            return _iClientRepository.Add(cliente);
        }

        public List<Client> GetAll()
        {
            return _iClientRepository.GetAll();
        }

        public Client GetByCPF(string cpf)
        {
            return _iClientRepository.GetByCPF(cpf);
        }

        public void Validar(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
