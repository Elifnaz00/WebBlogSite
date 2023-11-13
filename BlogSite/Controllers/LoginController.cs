using BussinesLayer.Concrate;
using DataAccesLayer.Concrate;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogSite.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        AdminLoginManager al = new AdminLoginManager();
       
        
              
        
        [HttpGet]
        public ActionResult AdminSignİn()
        {
            return View();
        }
        
        
        [HttpPost]
        public ActionResult AdminSignİn(Admin user)
        {
                Context c = new Context();
                var usr = c.Admins.SingleOrDefault(x => x.Mail == user.Mail && x.Password == user.Password);
                if (usr != null)
                {
                  FormsAuthentication.SetAuthCookie(usr.Mail, false);
                  Session["Mail"] = usr.Mail.ToString();
                  
                    return RedirectToAction("AdminBlogList", "Blog");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre yanlış.");
               
                     return RedirectToAction("AdminSignİn", "Login");
                } 
        }


        [HttpGet]
        public ActionResult AdminSignup()
        {
            var admin = al.GetAll(); 
            return View(admin);
        }

        [HttpPost]
        public ActionResult AdminSignup(Admin c)
        {
            al.AdminSignUp(c);
            return RedirectToAction("AdminSignİn");
        }



        [HttpGet]
        public ActionResult AuthorSignİn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AuthorSignİn(Author p)
        {
            Context c = new Context();

            var usr = c.Authors.SingleOrDefault(x => x.Mail == p.Mail && x.Password == p.Password);

            if (usr != null)
            {
                FormsAuthentication.SetAuthCookie(usr.Mail, false);
                Session["Mail"] = usr.Mail.ToString();

                return RedirectToAction("Index", "User");
            }
            else
            {
                return RedirectToAction("AuthorSignİn", "Login");
            }
        }
    }
}