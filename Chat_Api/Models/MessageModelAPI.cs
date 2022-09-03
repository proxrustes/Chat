using System;

namespace Chat_Api.Models
{
    public class MessageModelAPI
    {
        public int id { get; set; }

        public int chatId { get; set; }
        public int userId { get; set; }

        public string messageBody { get; set; }
        public DateTime messageDate { get; set; }

        public bool deletedForSelf { get; set; }
    }
}
