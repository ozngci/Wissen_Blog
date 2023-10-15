using Blog.DataAccess.Abstract;
using Blog.DataAccess.Contexts;
using Blog.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Concrete
{
    public class BlogPostLikeRepository : BaseRepository<BlogPostLike>, IBlogPostLikeRepository
    {
        private readonly BlogProjesiDbContext blogProjesiDbContext;


        public BlogPostLikeRepository(BlogProjesiDbContext blogProjesiDbContext) : base(blogProjesiDbContext)
        {
            this.blogProjesiDbContext = blogProjesiDbContext;

        }

        public async Task<BlogPostLike> AddLikeForBlog(BlogPostLike blogPostLike)
        {
            await blogProjesiDbContext.BlogPostLikes.AddAsync(blogPostLike);
            await blogProjesiDbContext.SaveChangesAsync();
            return blogPostLike;
        }

        public async Task<IEnumerable<BlogPostLike>> GetLikesForBlog(Guid blogPostId)
        {
            return await blogProjesiDbContext.BlogPostLikes.Where(x => x.BlogPostId == blogPostId).ToListAsync();
        }

        public async Task<int> GetTotalLikes(Guid blogPostId)
        {
            return await blogProjesiDbContext.BlogPostLikes.CountAsync(x => x.BlogPostId == blogPostId);
        }
    }
}
