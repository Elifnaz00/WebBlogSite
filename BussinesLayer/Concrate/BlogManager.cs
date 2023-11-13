using BussinesLayer.Abstract;
using DataAccesLayer.Abstract;
using DataAccesLayer.EntityFramewok;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Concrate
{
    public class BlogManager:IBlogService
    {
        IBlogDal _blogDal;
        
        
        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;

        }

        public List<Blog> GetAll()
        {
            return _blogDal.List();
        }


        public List<Blog> GetBlogByID(int id)
        {
            return _blogDal.List(x => x.BlogID == id);  
        }

        public List<Blog> GetBlogByAuthor(int id)
        {
            return _blogDal.List(x => x.AuthorID == id);
        }

        public List<Blog> GetCategoryByID(int id)
        {
            return _blogDal.List(x => x.CategoryID == id);
        }

        
        public List<Blog> GetList()
        {
            return _blogDal.List();
        }

      
        public Blog GetByID(int id)
        {
            return _blogDal.GetByID(id);
        }

        public void TDelete(Blog t)
        {
            _blogDal.Delete(t);
        }

        public void TUpdate(Blog t)
        {
            _blogDal.Update(t);
        }

        public void TAdd(Blog t)
        {
            _blogDal.Insert(t);
        }
    }
}
