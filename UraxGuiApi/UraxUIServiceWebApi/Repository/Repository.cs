using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;


namespace UraxUIServiceWebApi.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        
        protected DbContext Context { get; set; }

        public Repository(DbContext context)
        {
            Context = context;
        }

        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> GetAll(string include)
        {
            return Context.Set<TEntity>().Include(include).ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public IEnumerable<TEntity> FindDeep(Expression<Func<TEntity, bool>> predicate, string include)
        {
            return Context.Set<TEntity>().Include(include).Where(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();
        }
       

        public void AddRange(IEnumerable<TEntity> entities)
        {
           
                Context.Set<TEntity>().AddRange(entities);
                Context.SaveChanges();
               
           
            
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            Context.Entry(entity).State = EntityState.Deleted;
            Context.SaveChanges();

        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {

            Context.Set<TEntity>().RemoveRange(entities);
            Context.SaveChanges();
        }

        public void Update(TEntity entity, List<string> fields)
        {
            Context.Set<TEntity>().Attach(entity);
            foreach (var field in fields)
            {
                Context.Entry(entity).Property(field).IsModified = true;
            }
            Context.SaveChanges();
        }

        public void UpdateRange(IEnumerable<TEntity> entites, List<string> fields)
        {
            foreach (var entity in entites)
            {
                
                Context.Set<TEntity>().Attach(entity);
                foreach (var field in fields)
                {
                    Context.Entry(entity).Property(field).IsModified = true;
                }


                Context.SaveChanges();
                
              
            }
        }
        
    }
}