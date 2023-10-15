using Blog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Abstract
{
    public interface IBlogPostRepository:IBaseRepository<BlogPost>
    {

        Task<IEnumerable<BlogPost>> GetAllBlogPostAsync();
        Task<BlogPost?> UpdateBlogPostAsync(BlogPost blogPost);
        Task<BlogPost?> DeleteBlogPostAsync(Guid id);
        Task<BlogPost?> GetByUrlHandleAsync(string urlHandle);


        


    }
}
