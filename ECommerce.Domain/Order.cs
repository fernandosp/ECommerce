using System;

namespace ECommerce.Domain
{
    public class Order : Entity
    {
        public Client Client { get; set; }
        public OrderItens OrderItens { get; set; }
        public PaymentType PaymentType { get; set; }
        public bool IsOrderAproved { get; set; }
        public decimal Total { get; set; }

        public DateTime DateOrder { get; set; }
    }
}
