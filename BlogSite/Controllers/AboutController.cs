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
    public class AboutController : Controller
    {
        AboutManager an = new AboutManager(new EfAboutDal());
        AuthorManager auth = new AuthorManager(new EfAuthorDal());
        // GET: About
        public ActionResult Index()
        {
            var list1 = an.GetList();
            return View(list1);
        }

       
        public PartialViewResult Footer()
        {
            var list =an.GetList();
            return PartialView(list); 
        }

        
        public PartialViewResult MeetTheTeam()
        {
            var list2 = auth.GetList();
            return PartialView(list2);
        }

        [HttpGet]
        public ActionResult UpdateAboutList()
        {
            var aboutlist = an.GetList();
            return View(aboutlist);
        }

        [HttpPost]
        public ActionResult UpdateAbout(About p)
        {
            an.TUpdate(p);
            return RedirectToAction("UpdateAboutList");
        }


    }
}