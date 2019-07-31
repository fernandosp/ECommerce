
using DomainValidation.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Domain
{
    [Table("Client")]
    public class Client : Entity
    {
        /// <summary>
        /// Getting  all required of Customer's information to ensure register properly. 
        /// without all these info the register will not be saved.
        /// 
        /// </Name - Customer has to insert their Name and Surname> 
        /// </Email - Getting SMTP account >
        /// </CPF -  Identity on Revenue >
        /// </summary>
        public string Name { get; set; }
        public string Email { get; set; }

        public string CPF { get; set; }

       
    }
}
