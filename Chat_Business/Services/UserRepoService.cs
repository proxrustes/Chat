using AutoMapper;
using Chat_Business.Models;
using Chat_Business.Services.IServices;
using Chat_Database.Models;
using Chat_Database.Repositories;
using System.Collections.Generic;

namespace Chat_Business.Services
{
    public class UserRepoService : IUserService
    {
        private readonly IRepository<UserEntity> repo;
        private readonly Mapper mapper;

        public UserRepoService(IRepository<UserEntity> _repo)
        {
            repo = _repo;
            mapper = new Mapper(AutoMapper_Business.GetMapperConfiguration());
        }
        public IEnumerable<UserModelBL> GetAll() =>
             mapper.Map<IEnumerable<UserModelBL>>(repo.GetAll());

        public UserModelBL GetById(int id) =>
            mapper.Map<UserModelBL>(repo.GetById(id));

       
        public void Create(UserModelBL value) =>
            repo.Create(mapper.Map<UserEntity>(value));

        public void Update(UserModelBL value) =>
            repo.Update(mapper.Map<UserEntity>(value));

        public void Delete(int id) =>
            repo.Delete(id);
    }
}
