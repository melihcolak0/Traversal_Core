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
    public class ContactUsMessageManager : IContactUsMessageService
    {
        IContactUsMessageDal _contactUsMessageDal;

        public ContactUsMessageManager(IContactUsMessageDal contactUsMessageDal)
        {
            _contactUsMessageDal = contactUsMessageDal;
        }

        public List<ContactUsMessage> GetList()
        {
            return _contactUsMessageDal.GetList();
        }

        public void TAdd(ContactUsMessage t)
        {
            _contactUsMessageDal.Insert(t);
        }

        public void TDelete(ContactUsMessage t)
        {
            _contactUsMessageDal.Delete(t);
        }

        public List<ContactUsMessage> TGetActiveContactUsMessageList()
        {
            return _contactUsMessageDal.GetActiveContactUsMessageList();
        }

        public ContactUsMessage TGetById(int id)
        {
            return _contactUsMessageDal.GetById(id);
        }

        public List<ContactUsMessage> TGetPassiveContactUsMessageList()
        {
            return _contactUsMessageDal.GetPassiveContactUsMessageList();
        }

        public void TMakeContactUsMessagePassive(int id)
        {
            _contactUsMessageDal.MakeContactUsMessagePassive(id);
        }

        public void TUpdate(ContactUsMessage t)
        {
            _contactUsMessageDal.Update(t);
        }
    }
}
