using Blog.Business.Abstract;
using Blog.DataAccess.Abstract;
using Blog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Concrete
{
    public class BlogPostManager : ManagerBase<BlogPost>, IBlogPostManager
    {
        private readonly IBlogPostRepository blogPostRepository;

        public BlogPostManager(IBlogPostRepository blogPostRepository) : base(blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }

        public async Task<BlogPost?> DeleteBlogPostAsync(Guid id)
        {
            return await blogPostRepository.DeleteBlogPostAsync(id);
        }

        public async Task<IEnumerable<BlogPost>> GetAllBlogPostAsync()
        {
            return await blogPostRepository.GetAllBlogPostAsync();
        }

        

        public async Task<BlogPost?> GetByUrlHandleAsync(string urlHandle)
        {
            return await blogPostRepository.GetByUrlHandleAsync(urlHandle);
        }

        public async Task<BlogPost?> UpdateBlogPostAsync(BlogPost blogPost)
        {
            return await blogPostRepository.UpdateBlogPostAsync(blogPost);
        }
    }
}
