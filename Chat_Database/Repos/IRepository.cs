using Chat_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Database.Repositories
{
    public interface IRepository<TEntity> where TEntity : IHasKey
    {
        public IEnumerable<TEntity> GetAll();

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);

        public TEntity? GetById(int id);

        public void Create(TEntity entity);

        public void Update(TEntity entity);

        public void Delete(int id);
    }
}
