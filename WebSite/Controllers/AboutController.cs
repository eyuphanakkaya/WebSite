using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models.Entity;
using WebSite.Repositories;

namespace WebSite.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutRepository aboutRepository = new AboutRepository();
        public ActionResult Index()
        {
            var Deger = aboutRepository.List();
            return View(Deger);
        }
        [HttpGet]
        public ActionResult UpdateAbout()
        {
            var Deger = aboutRepository.Find(x => x.Id ==1);
            return View(Deger);
        }
        [HttpPost]
        public ActionResult UpdateAbout(TbAbout tbAbout)
        {
            var Deger = aboutRepository.Find(x => x.Id == 1);
            Deger.Name = tbAbout.Name;
            Deger.LastName=tbAbout.LastName;
            Deger.Adress = tbAbout.Adress;
            Deger.Phone= tbAbout.Phone;
            Deger.Explanation= tbAbout.Explanation;
            Deger.Mail = tbAbout.Mail;
            aboutRepository.TUpdate(Deger);
            return RedirectToAction("Index");
        }
    }
}