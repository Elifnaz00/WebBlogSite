using BussinesLayer.Concrate;
using DataAccesLayer.EntityFramewok;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSite.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        

        
        public ActionResult Index()
        {
            return View();
        }

        
        [HttpGet]
        public ActionResult SendMessage()
        {
            return View();
        }

       
        [HttpPost]
        public ActionResult SendMessage(Contact c)
        {
            c.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            cm.TAdd(c);
            return RedirectToAction("SendMessage");
        }

        
        public ActionResult SendBox()
        {
            var messagelist = cm.GetList();
            return View(messagelist);
        }

        
        public ActionResult MessageDetails(int id)
        {
            Contact contact=cm.GetByID(id);
            return View(contact);
        }




    } 
}