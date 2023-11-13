using AjaxControlToolkit;
using BussinesLayer.Concrate;
using DataAccesLayer.EntityFramewok;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSite.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal());

        // GET: Comment
        [AllowAnonymous]
        public PartialViewResult CommentList(int id)
        {
            var cList = commentManager.CommentByList(id);
            return PartialView(cList);
        }

        [AllowAnonymous]
        [HttpGet]
        public PartialViewResult LeaveComment(int id)
        {
            ViewBag.id = id;
            return PartialView();
        }

        [AllowAnonymous]
        [HttpPost]
        public PartialViewResult LeaveComment(Comment c)
        {


            c.CommentStatus = true;

            commentManager.TAdd(c);
           
            return PartialView();
        }

        public ActionResult AdminCommentsTrue()
        {
            var commentList = commentManager.CommentByStatusTrue();
            return View(commentList);
        }

        public ActionResult AdminCommentsFalse()
        {
            var commentList = commentManager.CommentByStatusFalse();

            return View(commentList);
        }


        //[HttpPost]
        public ActionResult StatusChangeToFalse(int id)
        {
            commentManager.CommentStatusChangeToFalse(id);
            return RedirectToAction("AdminCommentsTrue");
        }
        public ActionResult StatusChangeToTrue(int id)
        {
            commentManager.CommentStatusChangeToTrue(id);
            return RedirectToAction("AdminCommentsFalse");
        }





    }

}