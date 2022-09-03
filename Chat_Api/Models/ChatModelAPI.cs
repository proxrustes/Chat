using System.Collections.Generic;

namespace Chat_Api.Models
{
    public class ChatModelAPI
    {
        public int id { get; set; }
        public string chatName { get; set; }
        public ICollection<UserModelAPI> chatUsers { get; set; }
    }
}
