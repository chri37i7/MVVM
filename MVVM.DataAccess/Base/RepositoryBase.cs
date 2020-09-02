using Microsoft.EntityFrameworkCore;

using MVVM.DataAccess.Entities.Models;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVVM.DataAccess.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected NorthwindContext context;

        public RepositoryBase(NorthwindContext context)
        {
            Context = context;
        }

        public RepositoryBase() { }

        public virtual NorthwindContext Context
        {
            get { return context; }
            set { context = value; }
        }

        public void Add(T t)
        {
            context.Set<T>().Add(t);
            context.SaveChanges();
        }

        public void Delete(T t)
        {
            context.Set<T>().Remove(t);
            context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public virtual T GetBy(int id)
        {
            return context.Set<T>().Find(id);
        }

        public void Update()
        {
            context.SaveChanges();
        }
    }
}