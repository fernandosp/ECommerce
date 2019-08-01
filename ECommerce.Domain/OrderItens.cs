using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
/// <summary>
/// To List the amount of Products and to put it in onto PO
/// </summary>
namespace ECommerce.Domain
{
    [Table("OrderItens")]
    public class OrderItens : Entity
    {
        public Product Products { get; set; }
        public int Quantity { get; set; }

        public OrderItens(Product products, int quantity) : base()
        {
            Products = products;
            Quantity = quantity;
        }

        public OrderItens() : base()
        {

        }

    }

}
