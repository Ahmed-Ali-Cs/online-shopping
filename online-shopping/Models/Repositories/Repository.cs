using Microsoft.EntityFrameworkCore;
using online_shopping.Models.Data;
using System.Linq.Expressions;

namespace online_shopping.Models.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ShoppingDbContext db;
        internal DbSet<T> dbSet;

        public Repository(ShoppingDbContext db)
        {
            this.db = db;
            dbSet = db.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            IQueryable<T> query = dbSet;
            query.Where(expression);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }
    }
}
