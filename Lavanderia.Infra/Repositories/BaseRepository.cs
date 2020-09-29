using System.Threading.Tasks;
using Lavanderia.Domain.Repositories;
using Lavanderia.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Lavanderia.Infra.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly DataContext _dbContext;

        public BaseRepository(DataContext context)
        {
            _dbContext = context;
        }

        public virtual void Add(TEntity entity)
        {
            _dbContext.Add(entity);
        }
        
        public virtual void Update(TEntity entity)
        {
            _dbContext.Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _dbContext.Remove(entity);
        }

        public virtual async Task<bool> SaveChangesAsync()
        {
            return (await _dbContext.SaveChangesAsync()) > 0;
        }
    }
}