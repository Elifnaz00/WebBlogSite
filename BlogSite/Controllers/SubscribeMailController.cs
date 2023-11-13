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
    public class SubscribeMailController : Controller
    {
        SubscribeMailManager mm = new SubscribeMailManager(new EfMailDal());
        [AllowAnonymous]
        [HttpGet]
        public PartialViewResult AddMail()
        {
            return PartialView();
        }

        [AllowAnonymous]
        [HttpPost]
        public PartialViewResult AddMail(SubscribeMail p)
        {
           
            mm.TAdd(p);
            return PartialView();
        }
    }
}