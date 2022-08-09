using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models.Entity;
using WebSite.Repositories;

namespace WebSite.Controllers
{
    public class HobbiesController : Controller
    {
        // GET: Hobbies
        HobbiesRepository hobbiesRepository=new HobbiesRepository();
        public ActionResult Index()
        {
            var Deger = hobbiesRepository.List();
            return View(Deger);
        }
        [HttpGet]
        public ActionResult AddHobby()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddHobby(TbHobbies tbHobbies)
        {
            hobbiesRepository.TAdd(tbHobbies);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteHobby(int id)
        {
            var Deger = hobbiesRepository.Find(x => x.Id == id);
            hobbiesRepository.TDelete(Deger);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateHobby(int id)
        {
            var DegerBul=hobbiesRepository.Find(x => x.Id == id);   
            return View(DegerBul);
        }
        [HttpPost]
        public ActionResult UpdateHobby(TbHobbies tbHobbies)
        {
            var DegerBul = hobbiesRepository.Find(x => x.Id ==tbHobbies.Id);
            DegerBul.Explanation1 = tbHobbies.Explanation1;
            DegerBul.Explanation2 = tbHobbies.Explanation2;
            DegerBul.Photo = tbHobbies.Photo;
            hobbiesRepository.TUpdate(DegerBul);
            return RedirectToAction("Index");
        }
    }
}