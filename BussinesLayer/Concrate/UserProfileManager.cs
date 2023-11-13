using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Concrate
{
    public class UserProfileManager
    {
        Repository<Author> repouser = new Repository<Author>();
        Repository<Blog> repoblog = new Repository<Blog>();
 
        public List<Author> GetAuthorByMail(string p)
        {
            return repouser.List(x => x.Mail == p);
        }

        public List<Blog> GetBlogByAuthor(int p)
        {
            return repoblog.List(x => x.AuthorID == p);
        }

        public void EditAuthor(Author p)
        {
            Author author = repouser.Find(x => x.AuthorID == p.AuthorID);

            author.AuthorName = p.AuthorName;
            author.AuthorImage = p.AuthorImage;
            author.AboutShort = p.AboutShort;
            author.AuthorTitle = p.AuthorTitle;
            author.Mail = p.Mail;
            author.Password = p.Password;
            author.PhoneNumber = p.PhoneNumber;
            author.AuthorAbout = p.AuthorAbout;



             repouser.Update(author);


        }

    }
}
