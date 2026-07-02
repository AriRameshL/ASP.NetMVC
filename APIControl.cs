using AudioSeller.Models;
using System.Net;

namespace AudioSeller
{
    public class APIControl
    {
        public Customer GetCustomerDetails(string _Address)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5074/");
                var Cust = client.GetFromJsonAsync<Customer>(_Address).GetAwaiter().GetResult();

                return Cust;
            }
        }

    }
}
