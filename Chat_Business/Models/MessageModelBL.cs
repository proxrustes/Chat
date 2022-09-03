using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Business.Models
{
    public class MessageModelBL
    {
        public int id { get; set; }

        public int chatId { get; set; }

        public string userName { get; set; }
        public string messageBody { get; set; }
        public DateTime messageDate { get; set; }

        public bool deletedForSelf { get; set; }
    }
}
