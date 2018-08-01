using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckoutJSImplementation.Models
{
    public class Charge:BaseCharge
    {
        public string AuthenticationResponse { get; set; }
        public string SignatureValid { get; set; }
        public string Xid { get; set; }
        public string Enrolled { get; set; }
        public string Udf5 { get; set; }
        public string Udf4 { get; set; }
        public string Udf3 { get; set; }
        public string Udf2 { get; set; }
        public string Udf1 { get; set; }
        public string FailUrl { get; set; }
        public string SuccessUrl { get; set; }
        public LocalPayment LocalPayment { get; set; }
        public List<CustomerPaymentPlan> CustomerPaymentPlans { get; set; }
        public Address ShippingDetails { get; set; }
        public Address BillingDetails { get; set; }
        public string AuthCode { get; set; }
        public bool IsCascaded { get; set; }
        public string Status { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseAdvancedInfo { get; set; }
        public string ResponseMessage { get; set; }
        public Card Card { get; set; }
        public string TransactionIndicator { get; set; }
        public string CustomerId { get; set; }
        public int ChargeMode { get; set; }
        public string Created { get; set; }
        public bool LiveMode { get; set; }
        public string OriginalId { get; set; }
        public string Id { get; set; }
        public string Eci { get; set; }
        public string Cavv { get; set; }
    }
    public class LocalPayment
    {        
        public string PaymentUrl { get; set; }
    }

    public class CustomerPaymentPlan : CustomerPaymentPlanCreate
    {       
        public string CustomerPlanId { get; set; }
        public string Currency { get; set; }
        public string CardId { get; set; }
        public string CustomerId { get; set; }
        public RecurringPlanStatus? Status { get; set; }
        public int? RecurringCountLeft { get; set; }
        public int? TotalCollectedValue { get; set; }
        public int? TotalCollectedCount { get; set; }
        public string PreviousRecurringDate { get; set; }
        public string NextRecurringDate { get; set; }
    }

    public enum RecurringPlanStatus
    {
        FailedInitial = 0,
        Active = 1,
        Cancelled = 2,
        InArrears = 3,
        Suspended = 4,
        Completed = 5,
        AutoSuspended = 6
    }

    public class CustomerPaymentPlanCreate : BaseRecurringPlan
    {        
        public string StartDate { get; set; }
        public string PlanId { get; set; }
    }

    public class BaseRecurringPlan
    {      
        public string Name { get; set; }
        public string PlanTrackId { get; set; }
        public decimal? AutoCapTime { get; set; }
        public string Value { get; set; }
        public string Cycle { get; set; }
        public int? RecurringCount { get; set; }
    }

    public class Card : BaseCard
    {      
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public string Last4 { get; set; }
        public string Bin { get; set; }
        public string PaymentMethod { get; set; }
        public string FingerPrint { get; set; }
        public string CvvCheck { get; set; }
        public string AvsCheck { get; set; }
        public string ResponseCode { get; set; }
    }

    public class BaseCard
    {       
        public string Name { get; set; }
        public string ExpiryMonth { get; set; }
        public string ExpiryYear { get; set; }
        public Address BillingDetails { get; set; }
    }
}