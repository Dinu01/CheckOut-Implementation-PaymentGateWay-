using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckoutJSImplementation.Models
{
    public class AuthPayment
    {
        public string autoCapTime { get; set; }
        public string autoCapture { get; set; }
        public string email { get; set; }
        public string value { get; set; }
        public string currency { get; set; }
        public string trackId { get; set; }
        public string cardToken { get; set; }
        public string chargeMode { get; set; }
        public string failUrl { get; set; }
        public string successUrl { get; set; }
    }
}