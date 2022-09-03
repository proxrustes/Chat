using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Database.Models
{
    public class MessageEntity : IHasKey
    {
        public int id { get; set; }
       
        public int chatId { get; set; }

        public string userName { get; set; }

        [Required]
        public string messageBody { get; set; }
        public DateTime messageDate { get; set; }

        public bool deletedForSelf { get; set; }
    }
}
