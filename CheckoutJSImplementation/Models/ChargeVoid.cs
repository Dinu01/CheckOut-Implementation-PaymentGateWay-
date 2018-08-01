using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckoutJSImplementation.Models
{
    public class ChargeVoid : BaseChargeInfo
    {
        public List<Product> Products { get; set; }
    }
}