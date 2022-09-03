using Chat_Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Business.Services.IServices
{
        public interface IChatService
        {
            void Create(ChatModelBL value);
            void Update(ChatModelBL value);
            void Delete(int id);
            IEnumerable<ChatModelBL> GetAll();
            ChatModelBL GetById(int id);
        }
}
