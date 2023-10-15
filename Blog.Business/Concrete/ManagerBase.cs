using Blog.Business.Abstract;
using Blog.DataAccess.Abstract;
using Blog.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Concrete
{
    public class ManagerBase<T> : IManagerBase<T> where T : class
    {
        private readonly IBaseRepository<T> baseRepository;

        public ManagerBase(IBaseRepository<T> baseRepository)
        {
            this.baseRepository = baseRepository;
        }
        public async Task<T> AddAsync(T entity)
        {
           return await baseRepository.AddAsync(entity);
        }

       

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
        {
            return await baseRepository.GetAllAsync(filter);
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return (ICollection<T>)await baseRepository.GetAllAsync();
        }

        public async Task<IQueryable<T>> GetAllInclude(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] include)
        {
            return await baseRepository.GetAllInclude(filter, include);

        }

        public async Task<T?> GetAsync(Guid id)
        {
            return await baseRepository.GetAsync(id);
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await baseRepository.GetAsync(id);
        }



        
    }
}
