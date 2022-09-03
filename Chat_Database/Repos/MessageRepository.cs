using Chat_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Database.Repositories
{
    public class MessageRepository : GenericRerository<MessageEntity>
    {
        public MessageRepository(ApplicationDbContext context) : base(context)
        { }

    }
}
