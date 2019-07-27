using System.Collections.Generic;

namespace ECommerce.Domain
{
    public class OrderItens : Entity
    {
        public Product Products { get; set; }
        public int Quantity { get; set; }

    }

}
