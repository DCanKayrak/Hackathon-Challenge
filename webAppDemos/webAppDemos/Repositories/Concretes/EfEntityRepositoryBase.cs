using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using webAppDemos.Entities.Abstracts;
using webAppDemos.Repositories.Abstracts;

namespace webAppDemos.Repositories.Concretes
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var tempEntity = context.Entry(entity);
                tempEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var tempEntity = context.Entry(entity);
                tempEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity,bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? 
                    context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var tempEntity = context.Entry(entity);
                tempEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
