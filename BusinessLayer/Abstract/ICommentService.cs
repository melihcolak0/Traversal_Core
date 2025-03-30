using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService : IGenericService<Comment>
    {
        List<Comment> TGetDestListByFilterById(int id);

        List<Comment> TGetCommentListWithDestById(int id);

        List<Comment> TGetCommentListWithDest();
    }
}
