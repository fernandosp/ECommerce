
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Domain
{
    [Table("ProductType")]
    public class ProductType : Entity
    {
        public string Name { get; set; }
    }
}
