using AutoMapper;
using Blog.DataAccess.DTO;
using Blog.Entity.Entities;

namespace Blog.Web.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Tag, AddTagRequest>();
            CreateMap<AddTagRequest, Tag>();

            CreateMap<Tag, EditTagRequest>();
            CreateMap<EditTagRequest, Tag>();

            CreateMap<BlogPost, AddBlogPostRequest>();
            CreateMap<AddBlogPostRequest, BlogPost>();

            CreateMap<BlogPost, EditBlogPostRequest>();
            CreateMap<EditBlogPostRequest, BlogPost>();
        }

    }
}
