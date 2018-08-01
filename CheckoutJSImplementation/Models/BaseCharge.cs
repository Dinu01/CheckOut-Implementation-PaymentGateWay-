using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckoutJSImplementation.Models
{
    public class BaseCharge : BaseChargeInfo
    {
        public bool? RiskCheck { get; set; }
        public BillingDescriptor Descriptor { get; set; }
        public Address ShippingDetails { get; set; }
        public Address BillingDetails { get; set; }
        public List<Product> Products { get; set; }
        public string RedirectUrl { get; set; }
        public string CustomerName { get; set; }
        public string SuccessUrl { get; set; }
        public string CustomerId { get; set; }
        public string CustomerIp { get; set; }
        public decimal AutoCapTime { get; set; }
        public string AutoCapture { get; set; }
        public bool AttemptN3D { get; set; }
        public int ChargeMode { get; set; }
        public string Currency { get; set; }
        public string Value { get; set; }
        public string Email { get; set; }
        public string FailUrl { get; set; }
    }

    public class BillingDescriptor
    {
       

        public string Name { get; set; }
        public string City { get; set; }
    }

    public class Address
    {        
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public Phone Phone { get; set; }
    }
    public class Phone
    {       
        public string CountryCode { get; set; }
        public string Number { get; set; }
    }
    public class Product
    {       
        public string Name { get; set; }
        public string Description { get; set; }
        public string Sku { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public decimal ShippingCost { get; set; }
        public string TrackingUrl { get; set; }
    }
}