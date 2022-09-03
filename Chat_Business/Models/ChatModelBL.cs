using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Business.Models
{
    public class ChatModelBL
    {
        public int id { get; set; }
        public string chatName { get; set; }
        public ICollection<UserModelBL> chatUsers { get; set; }
    }
}
