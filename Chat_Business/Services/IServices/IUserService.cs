using Chat_Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Business.Services.IServices
{
    public interface IUserService
    {
        void Create(UserModelBL value);
        void Update(UserModelBL value);
        void Delete(int id);
        IEnumerable<UserModelBL> GetAll();
        UserModelBL GetById(int id);
    }
   
}
