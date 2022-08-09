using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models.Entity;
using WebSite.Repositories;

namespace WebSite.Controllers
{
    public class DocumentsController : Controller
    {
        // GET: Documents
        DocumentRepository documentRepository = new DocumentRepository();
        public ActionResult Index()
        {
            var Deger = documentRepository.List();
            return View(Deger);
        }
        public ActionResult DeleteDoc(int id)
        {
            var Deger = documentRepository.Find(x => x.Id == id);
            documentRepository.TDelete(Deger);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateDoc(int id)
        {
            var Deger=documentRepository.Find(x => x.Id == id);
            return View(Deger);
        }
        [HttpPost]
        public ActionResult UpdateDoc(TbDocuments tbDocuments)
        {
            var Deger=documentRepository.Find(x=>x.Id == tbDocuments.Id);
            Deger.Explanation = tbDocuments.Explanation;
            Deger.Date = tbDocuments.Date;
            documentRepository.TUpdate(Deger);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddDoc()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDoc(TbDocuments tbDocuments)
        {
            documentRepository.TAdd(tbDocuments);
            return RedirectToAction("Index");
        }
    }
}