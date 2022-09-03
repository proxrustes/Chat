using Chat_Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chat_Database.Repositories
{
    public class GenericRerository<TEntity> : IRepository<TEntity> where TEntity : class, IHasKey
    {
        protected readonly ApplicationDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRerository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }
       
        public void Create(TEntity entity)
        {
            var model = GetById(entity.id);
            if (model != null)
            {
                throw new ArgumentException("The id is already used");
            }    
               
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }
        public IEnumerable<TEntity> GetAll() =>
           _dbSet.AsNoTracking().ToList();

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate) =>
            _dbSet.AsNoTracking().Where(predicate).ToList();

        public TEntity? GetById(int id) =>
            _dbSet.AsNoTracking().FirstOrDefault(entity => entity.id == id);

        public void Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = GetById(id);
            if (model == null)
                throw new ArgumentException("not found (sad kawai face)");

            _dbSet.Remove(model);
            _dbContext.SaveChanges();
        }
    }
}
