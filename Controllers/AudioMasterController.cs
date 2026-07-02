using AspNetCoreGeneratedDocument;
using AudioSeller.DbConnect;
using AudioSeller.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.IO;

namespace AudioSeller.Controllers
{
    public class AudioMasterController : Controller
    {
        private ApplicationDbContext m_ApplicationDbContext;
        private IWebHostEnvironment m_WebHostEnvironment;
        public AudioMasterController(ApplicationDbContext _DbContext, IWebHostEnvironment webHostEnvironment)
        {
            m_ApplicationDbContext = _DbContext;
            m_WebHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<AudioMaster> audioMasters = m_ApplicationDbContext.AudioMaster.ToList();
            return View(audioMasters);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AudioMaster audioMaster)
        {
            var files = HttpContext.Request.Form.Files;
            string WebRootPath = m_WebHostEnvironment.WebRootPath;

            if (files.Count > 0)
            {
                string NewFileName = Guid.NewGuid().ToString();
                var Upload = Path.Combine(WebRootPath, @"images\AudioCover");
                var extenstion = Path.GetExtension(files[0].FileName);
                using (var filestream = new FileStream(Path.Combine(Upload, NewFileName + extenstion), FileMode.Create))
                {
                    files[0].CopyTo(filestream);
                }
                audioMaster.CoverImage = @"\images\AudioCover\" + NewFileName + extenstion;

            }

            if (ModelState.IsValid)
            {
                m_ApplicationDbContext.AudioMaster.Add(audioMaster);
                m_ApplicationDbContext.SaveChanges();
                TempData["Success"] = "Saved Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public IActionResult Details(int _AudioId)
        {
            AudioMaster audioMaster = m_ApplicationDbContext.AudioMaster.FirstOrDefault(a => a.AudioId == _AudioId);

            return View(audioMaster);
        }
        [HttpGet]
        public IActionResult Edit(int _AudioId)
        {
            AudioMaster audioMaster = m_ApplicationDbContext.AudioMaster.FirstOrDefault(a => a.AudioId == _AudioId);
            return View(audioMaster);
        }
        [HttpPost]
        public IActionResult Edit(AudioMaster audioMaster)
        {
            var files = HttpContext.Request.Form.Files;
            string NewFileName = Guid.NewGuid().ToString();
            if (files.Count > 0)
            {
                string Upload = Path.Combine(m_WebHostEnvironment.WebRootPath, @"images/AudioCover");
                var extenstion = Path.GetExtension(files[0].FileName);
                string WebRootPath = m_WebHostEnvironment.WebRootPath;

                AudioMaster OldAudioMaster = m_ApplicationDbContext.AudioMaster.AsNoTracking().FirstOrDefault(x => x.AudioId == audioMaster.AudioId);
                if(System.IO.File.Exists(Path.Combine(WebRootPath + OldAudioMaster.CoverImage)))
                {
                    System.IO.File.Delete(Path.Combine(WebRootPath + OldAudioMaster.CoverImage));
                }


                using (FileStream oFileStream = new FileStream(Path.Combine(Upload, NewFileName + extenstion), FileMode.Create))
                {
                    files[0].CopyTo(oFileStream);
                }
                audioMaster.CoverImage = @"\images\AudioCover\" + NewFileName + extenstion;
            }
            if (ModelState.IsValid)
            {
                m_ApplicationDbContext.AudioMaster.Update(audioMaster);
                m_ApplicationDbContext.SaveChanges();
                TempData["Warning"] = "Ediited Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int _AudioId)
        {
            AudioMaster audioMaster = m_ApplicationDbContext.AudioMaster.FirstOrDefault(a => a.AudioId == _AudioId);
            return View(audioMaster);
        }
        [HttpPost]
        public IActionResult Delete(AudioMaster audioMaster)
        {
            var files = HttpContext.Request.Form.Files;
            string NewFileName = Guid.NewGuid().ToString();
            if (audioMaster.CoverImage !=null)
            {
                 string WebRootPath = m_WebHostEnvironment.WebRootPath;

                AudioMaster OldAudioMaster = m_ApplicationDbContext.AudioMaster.AsNoTracking().FirstOrDefault(x => x.AudioId == audioMaster.AudioId);
                if (System.IO.File.Exists(Path.Combine(WebRootPath + OldAudioMaster.CoverImage)))
                {
                    System.IO.File.Delete(Path.Combine(WebRootPath + OldAudioMaster.CoverImage));
                }
            }
            if (audioMaster.AudioId>0)
            {
                m_ApplicationDbContext.AudioMaster.Remove(audioMaster);
                m_ApplicationDbContext.SaveChanges();
                TempData["Danger"] = "Deleted Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public IActionResult CardView()
        {
            List<AudioMaster>audioMasters=m_ApplicationDbContext.AudioMaster.ToList();
            return View(audioMasters);
        }

    }
}
