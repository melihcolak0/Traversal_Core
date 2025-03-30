using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IContactUsMessageDal : IGenericDal<ContactUsMessage>
    {
        List<ContactUsMessage> GetActiveContactUsMessageList();
        List<ContactUsMessage> GetPassiveContactUsMessageList();
        void MakeContactUsMessagePassive(int id);
    }
}
