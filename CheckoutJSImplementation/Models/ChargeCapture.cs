using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckoutJSImplementation.Models
{
    public class ChargeCapture : BaseChargeInfo
    {
        public string Value { get; set; }
        public List<Product> Products { get; set; }
    }
}