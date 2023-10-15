using Azure;
using Blog.DataAccess.Abstract;
using Blog.DataAccess.Contexts;
using Blog.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly BlogProjesiDbContext blogProjesiDbContext;

        public BaseRepository(BlogProjesiDbContext blogProjesiDbContext)
        {
            this.blogProjesiDbContext = blogProjesiDbContext;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await blogProjesiDbContext.Set<T>().AddAsync(entity);
            await blogProjesiDbContext.SaveChangesAsync();
            return entity;
        }

        

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
        {
            
            
                return await blogProjesiDbContext.Set<T>().ToListAsync();
            
        }

        public async Task<IQueryable<T>> GetAllInclude(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] include)
        {
            IQueryable<T> query;
            if (filter != null)
            {
                query = blogProjesiDbContext.Set<T>().Where(filter);
            }
            else
            {
                query = blogProjesiDbContext.Set<T>();
            }


            return include.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public async Task<T?> GetAsync(Guid id)
        {
            return await blogProjesiDbContext.Set<T>().FindAsync(id);
        }



        
    }
}
