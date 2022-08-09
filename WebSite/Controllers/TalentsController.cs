using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models.Entity;
using WebSite.Repositories;

namespace WebSite.Controllers
{
    public class TalentsController : Controller
    {
        // GET: Talents
        TalentsRepository talentsRepository=new TalentsRepository();
        public ActionResult Index()
        {
            var Deger = talentsRepository.List();
            return View(Deger);
        }
        [HttpGet]
        public ActionResult AddTalent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTalent(TbTalents tbTalents)
        {
            talentsRepository.TAdd(tbTalents);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateTalent(int id)
        {
            var Deger = talentsRepository.Find(x => x.Id == id);
            return View(Deger);
        }
        [HttpPost]
        public ActionResult UpdateTalent(TbTalents tbTalents)
        {
            var Deger = talentsRepository.Find(x => x.Id == tbTalents.Id);
            Deger.Talent = tbTalents.Talent;
            Deger.Ratio = tbTalents.Ratio;
            Deger.degree = tbTalents.degree;
            talentsRepository.TUpdate(Deger);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteTalent(int id)
        {
            var Deger=talentsRepository.Find(x => x.Id == id);
            talentsRepository.TDelete(Deger);
            return RedirectToAction("Index");
        }
    }
}