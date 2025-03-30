using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.ContactDTOs
{
    public class SendMessageDTO
    {
        public string Name { get; set; }

        public string Mail { get; set; }

        public string Subject { get; set; }

        public string MessageContent { get; set; }
    }
}
