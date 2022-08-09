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
        public ActionResult UpdateTrain()
        {
            return View();
        }

    }
}