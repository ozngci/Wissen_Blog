using Blog.DataAccess.Contexts;
using Blog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Abstract
{
    public interface ITagRepository:IBaseRepository<Tag>
    {

        Task<Tag> UpdateTagAsync(Tag tag);
        Task<Tag> DeleteTagAsync(Guid id);
        Task<IEnumerable<Tag>> GetAllTagAsync();
        


    }
}
