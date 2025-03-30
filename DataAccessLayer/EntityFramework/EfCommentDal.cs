using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> GetCommentListWithDestById(int id)
        {
            using (var context = new Context())
            {
                return context.Comments.Where(z => z.DestinationId == id).
                    Include(x => x.Destination).
                    Include(y => y.AppUser).ToList();
            }
        }

        public List<Comment> GetCommentListWithDest()
        {
            using (var context = new Context())
            {
                return context.Comments.Include(x => x.Destination).Include(y => y.AppUser).ToList();
            }
        }
    }
}
