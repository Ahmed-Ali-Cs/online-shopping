using System.Linq.Expressions;

namespace online_shopping.Models.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T,bool>> expression);
        void Add(T entity);
        void Delete(T entity);
    }
}
