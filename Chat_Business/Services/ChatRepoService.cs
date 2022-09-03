using AutoMapper;
using Chat_Business.Models;
using Chat_Business.Services.IServices;
using Chat_Database.Models;
using Chat_Database.Repositories;
using System.Collections.Generic;

namespace Chat_Business.Services
{
    public class ChatRepoService: IChatService
    {
        private readonly IRepository<ChatEntity> repo;
        private readonly Mapper mapper;

        public ChatRepoService(IRepository<ChatEntity> _repo)
        {
            repo = _repo;
            mapper = new Mapper(AutoMapper_Business.GetMapperConfiguration());
        }

        public IEnumerable<ChatModelBL> GetAll() =>
             mapper.Map<IEnumerable<ChatModelBL>>(repo.GetAll());

        public ChatModelBL GetById(int id) =>
            mapper.Map<ChatModelBL>(repo.GetById(id));

        public void Create(ChatModelBL value) =>
            repo.Create(mapper.Map<ChatEntity>(value));

        public void Update(ChatModelBL value) =>
            repo.Update(mapper.Map<ChatEntity>(value));

        public void Delete(int id) =>
            repo.Delete(id);
    }
}
