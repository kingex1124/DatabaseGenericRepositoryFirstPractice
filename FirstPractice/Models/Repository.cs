using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FirstPractice.Models
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbSet<TEntity> Dbset;
        private DbContext _dbContext;
        public Repository(DbContext dbContenxt)
        {
            _dbContext = dbContenxt;
            Dbset = _dbContext.Set<TEntity>();
        }


        public TEntity GetById(int id)
        {
            return Dbset.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Dbset;
        }

        public void Create(TEntity _entity)
        {
            Dbset.Add(_entity);
            _dbContext.SaveChanges();
        }

        public void Update(TEntity _entity)
        {
            _dbContext.Entry(_entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(TEntity _entity)
        {
            Dbset.Remove(_entity);
            _dbContext.SaveChanges();
        }
    }
}