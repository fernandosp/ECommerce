using System;

namespace ECommerce.Integration
{
    public class PaymentSlipStatus
    {
        public Paymentsliptransaction paymentSlipTransaction { get; set; }
        public string requestKey { get; set; }
        public DateTime createDate { get; set; }
        public float internalTimeMs { get; set; }
    }
}
