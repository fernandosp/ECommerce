using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Integration
{
    public class Paymentsliptransaction
    {
        public string reference { get; set; }
        public string affiliationKey { get; set; }
        public int amountInCents { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime authorizedAt { get; set; }
        public Paymentslip paymentSlip { get; set; }
        public int id { get; set; }
        public string key { get; set; }
    }
       
}
