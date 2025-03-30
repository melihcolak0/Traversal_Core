using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactUsMessageService : IGenericService<ContactUsMessage>
    {
        List<ContactUsMessage> TGetActiveContactUsMessageList();
        List<ContactUsMessage> TGetPassiveContactUsMessageList();
        void TMakeContactUsMessagePassive(int id);
    }
}
