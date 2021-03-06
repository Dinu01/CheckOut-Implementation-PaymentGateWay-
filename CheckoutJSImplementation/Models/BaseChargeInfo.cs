﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckoutJSImplementation.Models
{
    public class BaseChargeInfo
    {     
        public string Description { get; set; }
        public string TrackId { get; set; }
        public string Udf1 { get; set; }
        public string Udf2 { get; set; }
        public string Udf3 { get; set; }
        public string Udf4 { get; set; }
        public string Udf5 { get; set; }
        public Dictionary<string, string> Metadata { get; set; }
    }
}