using Paradigmi.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Models.Repositories
{
    public abstract class GenericRepository<T> where T : class
    {
        protected MyDbContext _ctx;

        public GenericRepository(MyDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Add(T entity) 
        {
            _ctx.Add(entity); 
        }

        public void Update(T entity)
        {
            _ctx.Update(entity);
        }

        public void Delete(T entity)
        {
            _ctx.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public T? Get(object id)
        {
            return _ctx.Set<T>().Find(id);
        }

        public void Save()
        {
            _ctx.SaveChanges();
        }



    }
}
