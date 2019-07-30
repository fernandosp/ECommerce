using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Domain
{   /// <summary>
    /// Getting all information to start the creating of Purchasing Order which afterwards to submit to the Client
    /// </summary>

    [Table("Order")]
    public class Order : Entity
    {
        public Client Client { get; set; }
        public int Client_Id { get; set; }
        public List<OrderItens> OrderItens { get; set; }
        public PaymentType PaymentType { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal Total { get; set; }
        public DateTime DateOrder { get; set; }
    }
}
