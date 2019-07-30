using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Integration
{
    public class Paymentslip
    {
        public DateTime dueDate { get; set; }
        public string barCode { get; set; }
        public int status { get; set; }
        public int id { get; set; }
        public string key { get; set; }
    }

}
