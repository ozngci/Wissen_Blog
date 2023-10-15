using Blog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Abstract
{
    public interface IBlogPostManager:IManagerBase<BlogPost>
    {
        Task<IEnumerable<BlogPost>> GetAllBlogPostAsync();
        Task<BlogPost?> UpdateBlogPostAsync(BlogPost blogPost);
        Task<BlogPost?> DeleteBlogPostAsync(Guid id);
        Task<BlogPost?> GetByUrlHandleAsync(string urlHandle);


        
    }
}
