using Blog.Business.Abstract;
using Blog.DataAccess.Abstract;
using Blog.DataAccess.Concrete;
using Blog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Concrete
{
    public class BlogPostLikeManager: ManagerBase<BlogPostLike>, IBlogPostLikeManager
    {
        private readonly IBlogPostLikeRepository blogPostLikeRepository;

        public BlogPostLikeManager(IBlogPostLikeRepository blogPostLikeRepository) : base(blogPostLikeRepository)
        {
            this.blogPostLikeRepository = blogPostLikeRepository;
        }

        public Task<BlogPostLike> AddLikeForBlog(BlogPostLike blogPostLike)
        {
            return blogPostLikeRepository.AddLikeForBlog(blogPostLike);
        }

        public Task<IEnumerable<BlogPostLike>> GetLikesForBlog(Guid blogPostId)
        {
            return blogPostLikeRepository.GetLikesForBlog(blogPostId);
        }

        public Task<int> GetTotalLikes(Guid blogPostId)
        {
            return blogPostLikeRepository.GetTotalLikes(blogPostId);
        }
    }
}
