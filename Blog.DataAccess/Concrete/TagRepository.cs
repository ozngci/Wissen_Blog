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
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        private readonly BlogProjesiDbContext blogProjesiDbContext;

        public TagRepository(BlogProjesiDbContext blogProjesiDbContext) : base(blogProjesiDbContext)
        {
            this.blogProjesiDbContext = blogProjesiDbContext;
        }

        public async Task<Tag> DeleteTagAsync(Guid id)
        {
            var existingTag = await blogProjesiDbContext.Tags.FindAsync(id);
            if (existingTag != null)
            {
                blogProjesiDbContext.Tags.Remove(existingTag);
                await blogProjesiDbContext.SaveChangesAsync();
                return existingTag;
            }
            return null;
        }

        public async Task<IEnumerable<Tag>> GetAllTagAsync()
        {
            return await blogProjesiDbContext.Tags.Include(x=>x.BlogPosts).ToListAsync();
            
        }

        public async Task<Tag> UpdateTagAsync(Tag tag)
        {
            var existingTag = await blogProjesiDbContext.Tags.FindAsync(tag.Id);
            if (existingTag != null)
            {
                existingTag.Name = tag.Name;
                existingTag.DisplayName = tag.DisplayName;
                await blogProjesiDbContext.SaveChangesAsync();
                return existingTag;
            }
            return null;
        }
    }
}
