using AudioSeller.DbConnect;
using AudioSeller.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Channels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AudioSeller.Controllers
{
    public class PurchaseController : Controller
    {
        private ApplicationDbContext m_DbContext;
        private IWebHostEnvironment m_WebHostEnvironment;

        public PurchaseController(ApplicationDbContext _DbContext, IWebHostEnvironment _WebHostEntry)
        {
            m_DbContext = _DbContext;
            m_WebHostEnvironment = _WebHostEntry;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.AudioList = new SelectList(m_DbContext.AudioMaster.ToList(), "AudioId", "AudioName");
            ViewBag.Gender = new SelectList(m_DbContext.Database.SqlQuery<Gender>($"Select *From GetGender()"), "GenderId", "GenderName");

            return View();
        }
        [HttpPost]
        public IActionResult Index(Purchase _Purchase)
        {
            if (int.Parse(_Purchase.AudioId.ToString()) > 0)
            {
                _Purchase.TranDate = DateTime.Now.Date;
                _Purchase.CreatedTime = DateTime.Now;
                _Purchase.Cancel = string.Empty;
                _Purchase.CanceledTime = null;

                if (_Purchase.Customer.CustomerId > 0)
                {
                    m_DbContext.Customer.Update(_Purchase.Customer);
                }
                else
                {
                    m_DbContext.Customer.Add(_Purchase.Customer);
                }
                m_DbContext.Purchase.Add(_Purchase);
                m_DbContext.SaveChanges();
                TempData["Success"] = "Transaction Saved Successfully";

                return RedirectToAction(nameof(Index));
            }
            TempData["Warning"] = "Enter Valid Details";
            return RedirectToAction(nameof(Index));

        }

        public IActionResult PurchaseView()
        {
            List<PurchaseViewModel> LstPurView = GetPurchase();
            return View(LstPurView);
        }
        public IActionResult CardView()
        {
            List<PurchaseViewModel> LstPurView = GetPurchase();
            return View(LstPurView);
        }

        [HttpGet]
        public IActionResult DetailView(int _TranNo)
        {
            PurchaseViewModel PurModelView = GetPurchase(_TranNo).First();
            return View(PurModelView);
        }
        [HttpPost]
        public IActionResult Cancel(int _TranNo)
        {
            try
            {
                Purchase purchase = m_DbContext.Purchase.AsNoTracking().First(x => x.TranNo == _TranNo);
                purchase.Cancel = "C";
                m_DbContext.Purchase.Update(purchase);
                m_DbContext.SaveChanges();
                return RedirectToAction(nameof(PurchaseView));
            }
            catch (Exception ex)
            {
                TempData["Danger"] = ex.Message;
            }
            return View();
        }
        #region "functions"
        // ADD THIS METHOD ONLY
        [HttpGet]
        public JsonResult GetRate(int id)
        {
            AudioMaster audioMaster = m_DbContext.AudioMaster
                                  .Where(x => x.AudioId == id)
                                  .FirstOrDefault();
            return Json(audioMaster);
        }
        public List<PurchaseViewModel> GetPurchase(int id = 0)
        {
            try
            {

                List<PurchaseViewModel> oLstPurmodview = (from p in m_DbContext.Purchase
                                                          join a in m_DbContext.AudioMaster on p.AudioId equals a.AudioId
                                                          join c in m_DbContext.Customer on p.CustomerId equals c.CustomerId
                                                          where p.TranNo == (id == 0 ? p.TranNo : id)
                                                          select new PurchaseViewModel
                                                          {
                                                              AudioId = p.AudioId,
                                                              AudioName = a.AudioName,
                                                              AuthorName = a.AuthorName,
                                                              TranNo = p.TranNo,
                                                              TranDate = p.TranDate,
                                                              Pieces = p.Pieces,
                                                              Rate = p.Rate,
                                                              Amount = p.Amount,
                                                              CreatedTime = p.CreatedTime,
                                                              Cancel = p.Cancel == "" ? "" : "Canceled",
                                                              CoverImage = a.CoverImage,
                                                              Customer = c
                                                          }).ToList();
                return oLstPurmodview;
            }
            catch (Exception) { throw; }
        }
        [HttpGet]
        public Customer GetCustomerDetail(string _MobileNo)
        {
            try
            {
                Customer customer = m_DbContext.Customer.Where(x => x.MobileNo == _MobileNo).FirstOrDefault();
                return customer;
            }
            catch (Exception) { throw; }
        }
        #endregion

    }
}