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

        public List<Comment> GetList()
        {
            return _commentDal.GetList();
        }

        public List<Comment> TGetDestListByFilterById(int id)
        {
            return _commentDal.GetListByFilter(x => x.DestinationId == id);
        }

        public void TAdd(Comment t)
        {
            _commentDal.Insert(t);
        }
        
        public void TDelete(Comment t)
        {
            _commentDal.Delete(t);
        }

        public Comment TGetById(int id)
        {
            return _commentDal.GetById(id);
        }

        public void TUpdate(Comment t)
        {
            _commentDal.Update(t);
        }

        public List<Comment> TGetCommentListWithDestById(int id)
        {
            return _commentDal.GetCommentListWithDestById(id);
        }

        public List<Comment> TGetCommentListWithDest()
        {
            return _commentDal.GetCommentListWithDest();
        }
    }
}
