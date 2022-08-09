using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models.Entity;
using WebSite.Repositories;

namespace WebSite.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactRepository contactRepository=new ContactRepository();
        public ActionResult Index()
        {
            var Deger = contactRepository.List();
            return View(Deger);
        }
    }
}