using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Repositories;
using WebSite.Models.Entity;

namespace WebSite.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbCVEntities Db = new DbCVEntities();
        public ActionResult Index()
        {
            var Deger = Db.TbAbout.ToList();
            return View(Deger);
        }

        public PartialViewResult _Education()
        {
            var Deger = Db.TbTrainings.ToList();
            return PartialView(Deger);
        }
        public PartialViewResult _Document()
        {
            var Deger = Db.TbDocuments.ToList();
            return PartialView(Deger);
        }
        public PartialViewResult _Talent()
        {
            var Deger = Db.TbTalents.ToList();
            return PartialView(Deger);
        }
        public PartialViewResult _About()
        {
            var Deger = Db.TbAbout.ToList();
            return PartialView(Deger);
        }
        [HttpGet]
        public PartialViewResult _Contact()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _Contact(TbContact tbContact)
        {
            tbContact.Date = DateTime.Now.ToShortDateString();
            Db.TbContact.Add(tbContact);
            Db.SaveChanges();
            return PartialView();
        }
        public PartialViewResult _Social()
        {
            var Deger= Db.TbSocial.ToList();
            return PartialView(Deger);
        }
        public PartialViewResult _Hobbies()
        {
            var Deger=Db.TbHobbies.ToList() ;
            return PartialView(Deger);
        }


    }
}