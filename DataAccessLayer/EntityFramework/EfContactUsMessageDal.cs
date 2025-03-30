using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfContactUsMessageDal : GenericRepository<ContactUsMessage>, IContactUsMessageDal
    {
        public List<ContactUsMessage> GetActiveContactUsMessageList()
        {
            using (var context = new Context())
            {
                var values = context.ContactUsMessages.Where(x => x.Status == true).ToList();
                return values;
            }            
        }

        public List<ContactUsMessage> GetPassiveContactUsMessageList()
        {
            using (var context = new Context())
            {
                var values = context.ContactUsMessages.Where(x => x.Status == false).ToList();
                return values;
            }
        }

        public void MakeContactUsMessagePassive(int id)
        {
            using (var context = new Context())
            {
                
                var value = context.ContactUsMessages.Find(id);
                if(value != null)
                {
                    value.Status = false;
                    context.Update(value);
                    context.SaveChanges();
                }                
            }
        }
    }
}
