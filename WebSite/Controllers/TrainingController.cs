using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models.Entity;
using WebSite.Repositories;

namespace WebSite.Controllers
{
    public class TrainingController : Controller
    {
        // GET: Training
        TrainingRepository trainingRepository=new TrainingRepository(); 
        public ActionResult Index()
        {
            var Deger = trainingRepository.List();
            return View(Deger);
        }
        [HttpGet]
        public ActionResult UpdateTrain(int id)
        {
            var Deger = trainingRepository.Find(x => x.Id == id);
            return View(Deger);
        }
        [HttpPost]
        public ActionResult UpdateTrain(TbTrainings tbTrainings)
        {
            var Deger=trainingRepository.Find(x=>x.Id==tbTrainings.Id);
            Deger.Title=tbTrainings.Title;
            Deger.Subtitle1=tbTrainings.Subtitle1;
            Deger.Subtitle2=tbTrainings.Subtitle2;
            Deger.AVG = tbTrainings.AVG;
            Deger.Date=tbTrainings.Date;
            trainingRepository.TUpdate(Deger);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteTrain(int id)
        {
            var Deger=trainingRepository.Find(x=>x.Id==id);
            trainingRepository.TDelete(Deger);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddTrain()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTrain(TbTrainings tbTrainings)
        {
            trainingRepository.TAdd(tbTrainings);
            return RedirectToAction("Index");
        }

    }
}