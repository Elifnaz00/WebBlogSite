using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstract
{
    public interface ICommentService:IGenericServices<Comment>
    {
        List<Comment> CommentByList(int id);
        List<Comment> CommentByStatusTrue();


    }
}
