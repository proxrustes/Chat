using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Business.Models
{
    public class UserModelBL
    {
        public int id { get; set; }

        public string userName { get; set; }
        public ICollection<ChatModelBL> userChats { get; set; }
    }
}
