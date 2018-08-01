using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CheckoutJSImplementation.Models;

using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace CheckoutJSImplementation.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AuthorizePayment()
        {
            var authDetails = new AuthPayment()
            {
                //autoCapTime = "24",
                autoCapture = "N",
                email = "sarah.mitchell@checkout.com",
                value = "1",
                currency = "USD",
                // trackId = "TRK12345",
                chargeMode = "2",
                cardToken = Convert.ToString(Request.Form["cardId"]),
                failUrl = Request.Url.AbsoluteUri.Replace(Request.Url.LocalPath, "/Home/FailURL"),
                successUrl= Request.Url.AbsoluteUri.Replace(Request.Url.LocalPath, "/Home/ThreeDResponce"),
                
            };

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://sandbox.checkout.com/api2/v2/");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", "sk_test_b2ce2577-0c3e-44f3-91e9-f14ea499cfce");
            client.DefaultRequestHeaders.Accept.Add(
       new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.PostAsJsonAsync("charges/token", authDetails).Result;
            string res = "";

            if (response.IsSuccessStatusCode)
            {
                using (HttpContent content = response.Content)
                {
                    // ... Read the string.
                    Task<string> result = content.ReadAsStringAsync();
                    res = result.Result;
                    var articles = JsonConvert.DeserializeObject<Charge>(res);
                                   
                    if(articles.ResponseCode== "10000" || articles.ResponseCode == "10001")
                    {
                        if(articles.RedirectUrl!=null)
                        return Redirect(articles.RedirectUrl);
                        else
                        {
                            // if any exception occour or some booking failed then we we use voidPayment else we capture the payment
                            // bool voidResult = voidPayment(articles.Id);
                            Capture captureResult = capturePayment(articles.Id);
                            if (captureResult != null)
                            {
                                if (captureResult.ResponseCode == "10000" || captureResult.ResponseCode == "10001")
                                {
                                    //Refond payment
                                    bool refundResult = refundPayment(captureResult.Id);
                                }
                            }
                        }
                    }

                }                
            }
            else
            {
                Task<string> result = response.Content.ReadAsStringAsync();
                res = result.Result;
            }
            return RedirectToAction("Index");
        }      
        public bool voidPayment(string chargeId)
        {
            // productDetails is optional. either we just pass ChargeVoid alias .Only charheId required
            var productDetails = new ChargeVoid()
            {                
                Products = new List<Product>(){
          new Product{
            Name="ipad 3",
            Price=1,
            Quantity=1,
            ShippingCost=10.5M,
            Description="Gold edition",
            Image="http://goofle.com/?id=12345",
            Sku="TR12345", TrackingUrl="http://tracket.com?id=123456"
        }
            }
            };
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", "sk_test_b2ce2577-0c3e-44f3-91e9-f14ea499cfce");
            client.DefaultRequestHeaders.Accept.Add(
             new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.PostAsJsonAsync("https://sandbox.checkout.com/api2/v2/charges/" + chargeId + "/void", productDetails).Result;
            string res = "";
            if (response.IsSuccessStatusCode)
            {
                using (HttpContent content = response.Content)
                {
                    // ... Read the string.
                    Task<string> result = content.ReadAsStringAsync();
                    res = result.Result;
                    var voidResponce = JsonConvert.DeserializeObject<CheckoutJSImplementation.Models.Void>(res);
                }

            }
            else
            {
                Task<string> result = response.Content.ReadAsStringAsync();
                res = result.Result;
            }

            return response.IsSuccessStatusCode;

        }

        public Capture capturePayment(string chargeId)
        {
            // cardChargCapture is optional. either we just pass ChargeCapture alias .Only chargeId required.

            var cardChargCapture = new ChargeCapture()
            {
                Value = "1",
                Products = new List<Product>(){
          new Product{
            Name="ipad 3",
            Price=1,
            Quantity=1,
            ShippingCost=10.5M,
            Description="Gold edition",
            Image="http://goofle.com/?id=12345",
            Sku="TR12345", TrackingUrl="http://tracket.com?id=123456"
        }
            }
            };
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", "sk_test_b2ce2577-0c3e-44f3-91e9-f14ea499cfce");
            client.DefaultRequestHeaders.Accept.Add(
           new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.PostAsJsonAsync("https://sandbox.checkout.com/api2/v2/charges/" + chargeId + "/capture", cardChargCapture).Result;
            string res = "";
            if (response.IsSuccessStatusCode)
            {
                using (HttpContent content = response.Content)
                {
                    // ... Read the string.
                    Task<string> result = content.ReadAsStringAsync();
                    res = result.Result;
                    var captureResponce = JsonConvert.DeserializeObject<CheckoutJSImplementation.Models.Capture>(res);
                    return captureResponce;
                }
            }
            else
            {
                Task<string> result = response.Content.ReadAsStringAsync();
                res = result.Result;
            }
            return null;
        }

        public bool refundPayment(string chargeId)
        {

            // productDetails is optional. either we just pass ChargeRefund alias .Only chargeId required.

            var productDetails = new ChargeRefund()
            {
                Value = "1",
                Products = new List<Product>(){
          new Product{
            Name="ipad 3",
            Price=1,
            Quantity=1,
            ShippingCost=10.5M,
            Description="Gold edition",
            Image="http://goofle.com/?id=12345",
            Sku="TR12345", TrackingUrl="http://tracket.com?id=123456"
        }
            }
            };
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", "sk_test_b2ce2577-0c3e-44f3-91e9-f14ea499cfce");
            client.DefaultRequestHeaders.Accept.Add(
             new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.PostAsJsonAsync("https://sandbox.checkout.com/api2/v2/charges/" + chargeId + "/refund", productDetails).Result;
            string res = "";
            if (response.IsSuccessStatusCode)
            {
                using (HttpContent content = response.Content)
                {
                    // ... Read the string.
                    Task<string> result = content.ReadAsStringAsync();
                    res = result.Result;
                    var voidResponce = JsonConvert.DeserializeObject<CheckoutJSImplementation.Models.Refund>(res);
                }
            }
            else
            {
                Task<string> result = response.Content.ReadAsStringAsync();
                res = result.Result;
            }

            return response.IsSuccessStatusCode;            
        }

        public ActionResult ThreeDResponce()
        {
            string paymentToken = Convert.ToString(Request["cko-payment-token"]);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://sandbox.checkout.com/api2/v2/");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", "sk_test_b2ce2577-0c3e-44f3-91e9-f14ea499cfce");
            var response = client.GetAsync("charges/"+ paymentToken + "").Result;
            string res = "";

            if (response.IsSuccessStatusCode)
            {
                using (HttpContent content = response.Content)
                {
                    // ... Read the string.
                    Task<string> result = content.ReadAsStringAsync();
                    res = result.Result;
                    var articles = JsonConvert.DeserializeObject<Charge>(res);

                    if (articles.ResponseCode == "10000" || articles.ResponseCode == "10001")
                    {
                        // if any exception occour or some booking failed then we we use voidPayment else we capture the payment
                        // bool voidResult = voidPayment(articles.Id);

                        Capture captureResult = capturePayment(articles.Id);
                            if (captureResult != null)
                            {
                                // Free the capture payment                               
                                if (captureResult.ResponseCode== "10000" || captureResult.ResponseCode == "10001")
                                {
                                    //Refond payment
                                    bool refundResult = refundPayment(captureResult.Id);
                                }
                            }
                        
                    }

                }
            }
            else
            {
                Task<string> result = response.Content.ReadAsStringAsync();
                res = result.Result;
            }
            return RedirectToAction("Index");
            
        }

        public ActionResult FailURL()
        {
            string paymentToken = Convert.ToString(Request["cko-payment-token"]);
            return View();
        }
    }
}