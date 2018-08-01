using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckoutJSImplementation.Models
{
    public class Void:BaseChargeInfo
    {
        public string Id { get; set; }
        public string OriginalId { get; set; }
        public bool LiveMode { get; set; }
        public string Created { get; set; }
        public decimal Value { get; set; }
        public string Currency { get; set; }
        public string ResponseMessage { get; set; }
        public string ResponseAdvancedInfo { get; set; }
        public string ResponseCode { get; set; }
        public string Status { get; set; }
        public List<Product> Products { get; set; }
    }
}