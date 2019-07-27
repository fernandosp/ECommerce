
using DomainValidation.Validation;

namespace ECommerce.Domain
{
   public class Client : Entity
    {
        /// <summary>
        /// Getting  all required of Buyer's information to ensure registry properly 
        /// </summary>
        public string Name { get; set; }
        public string Email { get; set; }

        public string CPF { get; set; }

       
    }
}
