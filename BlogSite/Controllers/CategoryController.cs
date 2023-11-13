using BussinesLayer.Concrate;
using BussinesLayer.Validation_Rules;
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
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        // GET: Category
       
       

        [AllowAnonymous]
        public PartialViewResult BlogDetailsCategory()
        {
            var categorylist = cm.GetList();
            return PartialView(categorylist);
        }

        public ActionResult AdminCategoryList()
        {
            
            var categoryvalues1 = cm.GetList();
            return View(categoryvalues1);
        }


        [HttpGet]
        public ActionResult AdminCategoryAdd()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult AdminCategoryAdd(Category p)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(p);
            if(results.IsValid)
            {
                cm.TAdd(p);
                return RedirectToAction("AdminCategoryList");
            }

            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }

            
        }

        [HttpGet]
        public ActionResult CategoryEdit(int id)
        {
            Category category = cm.GetByID(id);
            return View(category);
        }


        [HttpPost]
        public ActionResult CategoryEdit(Category p)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(p);
            if (results.IsValid)
            {
                cm.TUpdate(p);
                return RedirectToAction("AdminCategoryList");
            }

            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }

            
        }
        public ActionResult CategoryDelete(int id)
        {
            {
                cm.CategoryStatusChangeFalse(id);
                return RedirectToAction("AdminCategoryList");

            }
        }
        public ActionResult CategoryActive(int id)
        {
            {
                cm.CategoryStatusChangeTrue(id);
                return RedirectToAction("AdminCategoryList");

            }
        }
    }
}