using Chat_Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Business.Services.IServices
{
       public interface IMessageService
       {
            void Create(MessageModelBL value);
            void Update(MessageModelBL value);
            void Delete(int id);
            IEnumerable<MessageModelBL> GetAll();
            MessageModelBL GetById(int id);
       }
}
