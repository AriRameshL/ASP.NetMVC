using AudioSeller.DbConnect;
using AudioSeller.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static AudioSeller.ApplicationMain;

namespace AudioSeller.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext m_DbContext;
        public HomeController(ApplicationDbContext applicationDbContext)
        {
            m_DbContext = applicationDbContext;
        }
        public IActionResult Index()
        {
            int? OperCode = HttpContext.Session.GetInt32("OperCode");
            if (OperCode == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Login()
        {            
            return View();
        }
        #region "Function"
        public int CheckLogin(string UserName, string Pass)
        {
            try
            {
               int? OperCode= m_DbContext.Operator.Where(x => x.OperName.ToUpper() == UserName.ToUpper() & x.Password.ToString() == Pass).FirstOrDefault()?.OperCode;
                if (OperCode == null)
                {
                    return 0;
                }
                HttpContext.Session.SetInt32("OperCode", (int)OperCode);
                return (int)OperCode;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

    }
}
