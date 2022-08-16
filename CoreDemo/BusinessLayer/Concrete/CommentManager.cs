using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void CommentAdd(Comment comment)
        {
            _commentDal.Insert(comment);
        }

        //GetList metodundaki id, veritabanindaki id.
        //businesslayer katmanının manager sınıfları
        //WEB UI'da Entity Framework Repository ile birlikte çağırılacak
        //O zaman tüm katmanlar birbiriyle iletişim halinde olur
        public List<Comment> GetList(int id) 
        {
            return _commentDal.GetListAll(x => x.BlogID == id);
        }
    }
}
