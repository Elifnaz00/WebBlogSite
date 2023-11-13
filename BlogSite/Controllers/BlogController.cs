using BussinesLayer.Concrate;
using DataAccesLayer.Concrate;
using DataAccesLayer.EntityFramewok;
using EntityLayer.Concrete;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BlogSite.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogDal());
        CommentManager cm = new CommentManager(new EfCommentDal());


      
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult BlogList(int page = 1 )
        {
            var bloglist = bm.GetList().ToPagedList(page, 6);
            return PartialView(bloglist);
        }

        [AllowAnonymous]
        public PartialViewResult FeaturedPosts()
        {
            //1.Post
            var posttitle1 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select
                (y => y.BlogTitle).FirstOrDefault();
            var postimage1 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select
                (y => y.BlogImage).FirstOrDefault();
            var blogdate1 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select
               (y => y.BlogDate).FirstOrDefault();
            var blogpostid1 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select
              (y => y.BlogID).FirstOrDefault();


            ViewBag.posttitle1 = posttitle1;
            ViewBag.postimage1 = postimage1;
            ViewBag.blogdate1 = blogdate1;
            ViewBag.blogpostid1 = blogpostid1;


            //2.Post
            var posttitle2 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select
                (y => y.BlogTitle).FirstOrDefault();
            var postimage2 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select
                (y => y.BlogImage).FirstOrDefault();
            var blogdate2 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select
               (y => y.BlogDate).FirstOrDefault();
            var blogpostid2 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select
             (y => y.BlogID).FirstOrDefault();


            ViewBag.posttitle2 = posttitle2;
            ViewBag.postimage2 = postimage2;
            ViewBag.blogdate2 = blogdate2;
            ViewBag.blogpostid2 = blogpostid2;


            //3.Post
            var posttitle3 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 6).Select
                (y => y.BlogTitle).FirstOrDefault();
            var postimage3 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 6).Select
                (y => y.BlogImage).FirstOrDefault();
            var blogdate3 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 6).Select
               (y => y.BlogDate).FirstOrDefault();
            var blogpostid3 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 6).Select
            (y => y.BlogID).FirstOrDefault();

            ViewBag.posttitle3 = posttitle3;
            ViewBag.postimage3 = postimage3;
            ViewBag.blogdate3 = blogdate3;
            ViewBag.blogpostid3 = blogpostid3;



            //4.Post
            var posttitle4 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select
                (y => y.BlogTitle).FirstOrDefault();
            var postimage4 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select
                (y => y.BlogImage).FirstOrDefault();
            var blogdate4 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select
               (y => y.BlogDate).FirstOrDefault();
            var blogpostid4 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select
            (y => y.BlogID).FirstOrDefault();

            ViewBag.posttitle4 = posttitle4;
            ViewBag.postimage4 = postimage4;
            ViewBag.blogdate4 = blogdate4;
            ViewBag.blogpostid4 = blogpostid4;

            //4.Post
            var posttitle5 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select
                (y => y.BlogTitle).FirstOrDefault();
            var postimage5 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select
                (y => y.BlogImage).FirstOrDefault();
            var blogdate5 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select
               (y => y.BlogDate).FirstOrDefault();
            var blogpostid5 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select
           (y => y.BlogID).FirstOrDefault();

            ViewBag.posttitle5 = posttitle5;
            ViewBag.postimage5 = postimage5;
            ViewBag.blogdate5 = blogdate5;
            ViewBag.blogpostid5 = blogpostid5;
            return PartialView();
        }

        [AllowAnonymous]
        public PartialViewResult OtherFeaturedPosts()
        {
            return PartialView();
        }

        [AllowAnonymous]
        public ActionResult BlogDetails()
        {
            return View(); 
        }

        [AllowAnonymous]
        public PartialViewResult BlogCover(int id)
        {
            var BlogCoverList = bm.GetBlogByID(id);
            return PartialView(BlogCoverList);
        }

        [AllowAnonymous]
        public PartialViewResult BlogReadAll(int id)
        {
            var BlogDetailsList=bm.GetBlogByID(id);
            return PartialView(BlogDetailsList); 
        }

        [AllowAnonymous]
        public ActionResult BlogByCategory(int id)
        {
            var listBlogCategory=bm.GetCategoryByID(id);
            var CategoryName = bm.GetCategoryByID(id).Select(y => y.Category.CategoryName).FirstOrDefault();
            var Description = bm.GetCategoryByID(id).Select(y => y.Category.CategoryDescription).FirstOrDefault();
            ViewBag.CategoryName = CategoryName;
            ViewBag.Description = Description;
            return View(listBlogCategory);
        }

        
        public ActionResult AdminBlogList()
        {
            var AuthorBlogList =bm.GetList();
            return View(AuthorBlogList);
        }
        
        [Authorize]
        public ActionResult AdminBlogList2()
        {
            var AuthorBlogList = bm.GetList();
            return View(AuthorBlogList);
        }

        //[Authorize(Roles = "A")]
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
            
                bm.TAdd(p);
                
                return RedirectToAction("AdminBlogList");  
        }
        [HttpPost]
        public ActionResult DeleteBlog(int id)
        {
            Blog blog = bm.GetByID(id);
            bm.TDelete(blog);
            
            return RedirectToAction("AdminBlogList"); 
        }

        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            Blog blog = bm.GetByID(id);
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
        public ActionResult UpdateBlog(Blog p)
        {
            bm.TUpdate(p);
            return RedirectToAction("AdminBlogList");
        }

        public ActionResult CommentsBlog(int id)
        {
            var cList = cm.CommentByList(id);
            return View(cList);
             
        }

        public ActionResult AuthorByIDBlog(int id)
        {
            var list=bm.GetBlogByAuthor(id);
            return View(list);
        }



    }
}
