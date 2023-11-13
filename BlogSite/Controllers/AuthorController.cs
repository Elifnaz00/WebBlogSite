using BussinesLayer.Concrate;
using DataAccesLayer.EntityFramewok;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSite.Controllers
{
    public class AuthorController : Controller
    {
        BlogManager blogmanager = new BlogManager(new EfBlogDal());
        AuthorManager authormanager = new AuthorManager(new EfAuthorDal());
        // GET: Author
        [AllowAnonymous]
        public PartialViewResult AuthorAbout(int id)
        {
            var list = blogmanager.GetBlogByID(id);
            return PartialView(list);
        }

        [AllowAnonymous]
        public PartialViewResult AuthorPopularPost(int id)
        {
            var blogauthorid = blogmanager.GetList().Where(x => x.BlogID == id).Select(y => y.AuthorID).FirstOrDefault();
            var authorblogs = blogmanager.GetBlogByAuthor(blogauthorid);
            return PartialView(authorblogs);
        }

    

        [AllowAnonymous]
        public ActionResult Authors()
        {
            var list = authormanager.GetList();
            return View(list);
        }

        [HttpGet]
        public ActionResult NewAuthor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewAuthor(Author c)
        {
            authormanager.TAdd(c);
            return RedirectToAction("Authors");

        }

        [HttpGet]
        public ActionResult EditAuthor(int id)
        {
            Author author = authormanager.GetByID(id);

            return View(author);
        }

        [HttpPost]
        public ActionResult EditAuthor(Author p)
        {
            authormanager.TUpdate(p);
            return RedirectToAction("Authors");
        }





    }
}