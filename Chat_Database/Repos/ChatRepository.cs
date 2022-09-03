using Chat_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Database.Repositories
{
    public class ChatRepository : GenericRerository<ChatEntity>
    {
        public ChatRepository(ApplicationDbContext context) : base(context)
        { }

    }
}
