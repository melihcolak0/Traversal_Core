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
    public class ReservationManager : IReservationService
    {
        IReservationDal _reservationDal;

        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public List<Reservation> GetList()
        {
            return _reservationDal.GetList();
        }

        public void TAdd(Reservation t)
        {
            _reservationDal.Insert(t);
        }

        public void TDelete(Reservation t)
        {
            _reservationDal.Delete(t);
        }

        public Reservation TGetById(int id)
        {
            return _reservationDal.GetById(id);
        }

        public List<Reservation> TGetListReservationByApproved(int id)
        {
            return _reservationDal.GetListReservationByApproved(id);
        }

        public List<Reservation> TGetListReservationByPast(int id)
        {
            return _reservationDal.GetListReservationByPast(id);
        }

        public List<Reservation> TGetListReservationByPendingApproval(int id)
        {
            return _reservationDal.GetListReservationByPendingApproval(id);
        }

        public void TUpdate(Reservation t)
        {
            _reservationDal.Update(t);
        }
    }
}
