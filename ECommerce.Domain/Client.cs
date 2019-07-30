
using DomainValidation.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Domain
{
    [Table("Client")]
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
