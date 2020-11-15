using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TopLearn.Core.Services.Interfaces.Base
{
    public interface IBaseService<TEntity> where  TEntity: class
    {

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> where = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null , string includes="");


        TEntity GetById(object id);

        void Update(TEntity entity);

        void Add(TEntity entity);
        
        void Delete(object id);

        void Delete(TEntity entity);

        void Save();




    }
}
