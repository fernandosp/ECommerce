using System;

namespace ECommerce.Integration.Request
{
    public class PaymentSlipRequest
    {
        public string Reference { get; set; }
        public long AmountInCents { get; set; }
        public string RequestKey { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
