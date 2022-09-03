using AutoMapper;
using Chat_Business.Models;
using Chat_Business.Services.IServices;
using Chat_Database.Models;
using Chat_Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Business.Services
{
    public class MessageRepoService: IMessageService
    {
        private readonly IRepository<MessageEntity> repo;
        private readonly Mapper mapper;

        public MessageRepoService(IRepository<MessageEntity> _repo)
        {
            repo = _repo;
            mapper = new Mapper(AutoMapper_Business.GetMapperConfiguration());
        }

        public IEnumerable<MessageModelBL> GetAll() =>
             mapper.Map<IEnumerable<MessageModelBL>>(repo.GetAll());

        public MessageModelBL GetById(int id) =>
            mapper.Map<MessageModelBL>(repo.GetById(id));

        public void Create(MessageModelBL value) =>
            repo.Create(mapper.Map<MessageEntity>(value));

        public void Update(MessageModelBL value) =>
            repo.Update(mapper.Map<MessageEntity>(value));

        public void Delete(int id) =>
            repo.Delete(id);
    }
}
