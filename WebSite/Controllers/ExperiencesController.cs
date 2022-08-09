using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models.Entity;
using WebSite.Repositories;

namespace WebSite.Controllers
{
    public class ExperiencesController : Controller
    {
        // GET: Experiences
        ExperiencesRepository experiencesRepository=new ExperiencesRepository();
        public ActionResult Index()
        {
            var Deger = experiencesRepository.List();
            return View(Deger);
        }
        [HttpGet]
        public ActionResult AddExp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExp(TbExperiences tbExperiences)
        {
            experiencesRepository.TAdd(tbExperiences);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteExp(int id)
        {
            var Deger = experiencesRepository.Find(x => x.Id == id);
            experiencesRepository.TDelete(Deger);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateExp(int id)
        {
            var Deger = experiencesRepository.Find(x => x.Id == id);
            return View(Deger);
        }
        [HttpPost]
        public ActionResult UpdateExp(TbExperiences tbExperiences)
        {
            var Deger=experiencesRepository.Find(x => x.Id == tbExperiences.Id);
            Deger.Title=tbExperiences.Title;
            Deger.Subtitle = tbExperiences.Subtitle;
            Deger.Explanation = tbExperiences.Explanation;
            Deger.Date = tbExperiences.Date;
            experiencesRepository.TUpdate(Deger);
            return RedirectToAction("Index");
        }
    }
}