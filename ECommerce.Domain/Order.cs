using System;
using System.Collections.Generic;

namespace ECommerce.Domain
{   /// <summary>
/// Getting all information to start the creating of Purchasing Order which afterwards to submit to the Client
/// </summary>
    public class Order : Entity
    {
        public Client Client { get; set; }
        public List<OrderItens> OrderItens { get; set; }
        public PaymentType PaymentType { get; set; }
        public bool IsOrderAproved { get; set; }
        public decimal Total { get; set; }
        public DateTime DateOrder { get; set; }
    }
}
