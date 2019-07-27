using System.Collections.Generic;

namespace ECommerce.Domain
{
    public class OrderItens : Entity
    {
        List<Product> Products { get; set; }
    }

}
