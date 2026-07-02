using Microsoft.AspNetCore.Mvc;

namespace AudioSeller.Controllers
{
    public class CustomerController : Controller
    {

        private Models.Customer _customer;
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Models.Customer customer)
        {
            _customer = customer;
            return View();

        }
        public IActionResult GetCustomer()
        {
            return PartialView("Index");

        }
    }
}
