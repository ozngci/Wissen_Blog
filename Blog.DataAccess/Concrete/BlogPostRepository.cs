using Blog.DataAccess.Abstract;
using Blog.DataAccess.Contexts;
using Blog.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Concrete
{
    public class BlogPostRepository : BaseRepository<BlogPost>, IBlogPostRepository
    {
        private readonly BlogProjesiDbContext blogProjesiDbContext;

        public BlogPostRepository(BlogProjesiDbContext blogProjesiDbContext) : base(blogProjesiDbContext)
        {
            this.blogProjesiDbContext = blogProjesiDbContext;
        }

        public async Task<BlogPost?> DeleteBlogPostAsync(Guid id)
        {
            var existingBlogPost = await blogProjesiDbContext.BlogPosts.FindAsync(id);
            if (existingBlogPost != null)
            {
                blogProjesiDbContext.BlogPosts.Remove(existingBlogPost);
                await blogProjesiDbContext.SaveChangesAsync();
                return existingBlogPost;
            }
            return null;
        }

        public async Task<IEnumerable<BlogPost>> GetAllBlogPostAsync()
        {
            return await blogProjesiDbContext.BlogPosts.Include(x => x.Tags).ToListAsync();
        }

        

        public async Task<BlogPost?> GetByUrlHandleAsync(string urlHandle)
        {
            return await blogProjesiDbContext.BlogPosts.Include(x => x.Tags).FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);
        }

        public async Task<BlogPost?> UpdateBlogPostAsync(BlogPost blogPost)
        {
            var existingBlogPost = await blogProjesiDbContext.BlogPosts.Include(x => x.Tags).FirstOrDefaultAsync(x => x.Id == blogPost.Id);
            if (existingBlogPost != null)
            {
                existingBlogPost.Id = blogPost.Id;
                existingBlogPost.Heading = blogPost.Heading;
                existingBlogPost.PageTitle = blogPost.PageTitle;
                existingBlogPost.Content = blogPost.Content;
                existingBlogPost.ShortDescription = blogPost.ShortDescription;
                existingBlogPost.Author = blogPost.Author;
                existingBlogPost.FeaturedImageUrl = blogPost.FeaturedImageUrl;
                existingBlogPost.UrlHandle = blogPost.UrlHandle;
                existingBlogPost.Visible = blogPost.Visible;
                existingBlogPost.PublishedDate = blogPost.PublishedDate;
                existingBlogPost.Tags = blogPost.Tags;

                await blogProjesiDbContext.SaveChangesAsync();
                return existingBlogPost;
            }

            return null;
        }
    }
}
