using AudioSeller.DbConnect;
using AudioSeller.Models;
using Microsoft.AspNetCore.Mvc;

namespace AudioSeller.Controllers
{
    public class OperatorController : Controller
    {
        private ApplicationDbContext m_DbContext;
        public OperatorController(ApplicationDbContext context)
        {
            m_DbContext = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Operator _Operator)
        {
            if (ModelState.IsValid)
            {
                m_DbContext.Operator.Add(_Operator);
                m_DbContext.SaveChanges();
                TempData["Success"] = "Operator Saved Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public IActionResult DetailView()
        {
           List<Operator> LstOperator= m_DbContext.Operator.ToList();
            return View(LstOperator);
        }
    }
}
