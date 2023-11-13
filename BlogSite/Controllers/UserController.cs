using BussinesLayer.Concrate;
using DataAccesLayer.Concrate;
using DataAccesLayer.EntityFramewok;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogSite.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        UserProfileManager userProfile = new UserProfileManager();
        BlogManager blogManager = new BlogManager(new EfBlogDal()); 

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Partial1(string p)
        {
            p = (string)Session["Mail"];
            var profilevalues = userProfile.GetAuthorByMail(p);

            return PartialView(profilevalues);
        }

        public ActionResult BlogList(string p)
        {
            p = (string)Session["Mail"];
            Context c = new Context();
            int id = c.Authors.Where(x => x.Mail == p).Select(y => y.AuthorID).FirstOrDefault();
            var blogs = userProfile.GetBlogByAuthor(id);
            return View(blogs); 
        }

        [HttpGet]
        public ActionResult BlogUpdate(int id)
        {
            Blog blog = blogManager.GetByID(id);
            Context context = new Context();
            List<SelectListItem> values = (from x in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString(),
                                           }).ToList();
            ViewBag.values = values;

            List<SelectListItem> values2 = (from x in context.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.AuthorName,
                                                Value = x.AuthorID.ToString(),
                                            }).ToList();
            ViewBag.values2 = values2;
            return View(blog);

        }

        [HttpPost]
        public ActionResult BlogUpdate(Blog p)
        {
            blogManager.TUpdate(p);
            return RedirectToAction("BlogList" , "User");
        }


        [HttpGet]
        public ActionResult BlogEkle()
        {
            Context context = new Context();
            List<SelectListItem> values = (from x in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString(),
                                           }).ToList();
            ViewBag.values = values;

            List<SelectListItem> values2 = (from x in context.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.AuthorName,
                                                Value = x.AuthorID.ToString(),
                                            }).ToList();
            ViewBag.values2 = values2;
            return View();
        }

        [HttpPost]
        public ActionResult BlogEkle(Blog p)
        {

            blogManager.TAdd(p);

            return RedirectToAction("BlogList");
        }

        public ActionResult UpdateUserProfile(Author p)
        {
            userProfile.EditAuthor(p);
            return RedirectToAction("Index");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
           
            return RedirectToAction("AuthorSignİn" , "Login");
        }

        public ActionResult LogOutAdmin()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            return RedirectToAction("AdminSignİn", "Login");
        }










    }
}