using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IReservationService : IGenericService<Reservation>
    {
        public List<Reservation> TGetListReservationByApproved(int id);

        public List<Reservation> TGetListReservationByPast(int id);

        public List<Reservation> TGetListReservationByPendingApproval(int id);
    }
}
