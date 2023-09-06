using System.Linq.Expressions;
using webAppDemos.Entities.Abstracts;

namespace webAppDemos.Repositories.Abstracts
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
