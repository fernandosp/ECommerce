using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Integration
{
    public class Creditcard
    {
        public string branch { get; set; }
        public string number { get; set; }
        public string expirationDate { get; set; }
        public string securityCode { get; set; }
        public string holderName { get; set; }
        public int status { get; set; }
        public int id { get; set; }
        public string key { get; set; }
    }
}
