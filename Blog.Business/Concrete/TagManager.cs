using Blog.Business.Abstract;
using Blog.DataAccess.Abstract;

using Blog.Entity.Entities;

namespace Blog.Business.Concrete
{
    public class TagManager : ManagerBase<Tag>, ITagManager
    {
        private readonly ITagRepository tagRepository;

        public TagManager(ITagRepository tagRepository) : base(tagRepository)
        {
            this.tagRepository = tagRepository;
        }

        public virtual async Task<Tag> UpdateTagAsync(Tag tag)
        {
            return await tagRepository.UpdateTagAsync(tag);
        }

        public virtual async Task<Tag> DeleteTagAsync(Guid id)
        {
            return await tagRepository.DeleteTagAsync(id);
        }

        public async Task<IEnumerable<Tag>> GetAllTagAsync()
        {
            return await tagRepository.GetAllTagAsync();
        }
    }
}
