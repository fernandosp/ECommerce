using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Domain
{   /// <summary>
    /// Getting all information to start the creating of Purchasing Order which afterwards it will be submit by the Customer
    /// </Customer' name - Who had an order >
    /// </OrderItens - What are the products used in >
    /// </PaymentType - How customer is going to pay the shop cart for>
    /// </OrderStatus - Status of Order>
    /// </Total - Total of itens into Order >
    /// 
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
