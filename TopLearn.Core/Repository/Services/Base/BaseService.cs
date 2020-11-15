using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TopLearn.Core.Services.Interfaces.Base;
using TopLearn.DAL.Context;

namespace TopLearn.Core.Services.ServiceBase
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity:  class
    {
        private readonly TopLearnContext _context;

        private readonly DbSet<TEntity> _dbSet;

        public BaseService(TopLearnContext context)
        {
            _context = context;

            _dbSet = context.Set<TEntity>();
        }
      
        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> @where = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> @orderby = null, string includes = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (where != null)
            {
                query = query.Where(where);
            }

            if (orderby != null)
            {
                query = orderby(query);
            }

            if (includes != "")
            {
                foreach (string include in  includes.Split(','))
                {
                    query = query.Include(include);
                }
            }

            return query.ToList();
        }

        public virtual TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Update(TEntity entity)
        {
            try
            {
                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }

        //public virtual void Update(TEntity entity)
        //{
        //    _dbSet.Update(entity);
        //}

        public virtual void Add(TEntity entity)
        {
            try
            {
                _dbSet.Add(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public virtual void Delete(object id)
        {
            try
            {
                var entity = this.GetById(id);
                this.Delete(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }


        public virtual void Delete(TEntity entity)
        {

            try
            {
                if (_context.Entry(entity).State == EntityState.Detached)
                {
                    _dbSet.Attach(entity);
                }

                _dbSet.Remove(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
          
        }

        
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}
