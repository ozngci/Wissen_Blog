using AutoMapper;
using Blog.Business.Abstract;
using Blog.DataAccess.Abstract;
using Blog.DataAccess.Concrete;
using Blog.DataAccess.Contexts;
using Blog.DataAccess.DTO;
using Blog.Entity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blog.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminBlogPostsController : Controller
    {
        private readonly IBlogPostManager blogPostManager;
        private readonly ITagManager tagManager;
        private readonly IMapper mapper;

        public AdminBlogPostsController(IBlogPostManager blogPostManager, ITagManager tagManager, IMapper mapper)
        {
            this.blogPostManager = blogPostManager;
            this.tagManager = tagManager;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var tags = await tagManager.GetAllAsync();

            var model = new AddBlogPostRequest
            {
                Tags = tags.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
            };

            return View(model);
        }





        [HttpPost]
        public async Task<IActionResult> Add(AddBlogPostRequest addBlogPostRequest)
        {




            var blogPost = mapper.Map<BlogPost>(addBlogPostRequest);

            var selectedTags = new List<Tag>();

            foreach (var selectedTagId in addBlogPostRequest.SelectedTags)
            {
                var selectedTagIdAsGuid = Guid.Parse(selectedTagId);
                var existingTag = await tagManager.GetAsync(selectedTagIdAsGuid);

                if (existingTag != null)
                {
                    selectedTags.Add(existingTag);
                }
            }

            blogPost.Tags = selectedTags;

            await blogPostManager.AddAsync(blogPost);

            return RedirectToAction("List", "AdminBlogPosts");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {

            var blogPosts = await blogPostManager.GetAllBlogPostAsync();

            return View(blogPosts);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {

            var blogPost = await blogPostManager.GetAsync(id);
            var tagsDomainModel = await tagManager.GetAllTagAsync();


            if (blogPost != null)
            {
                var editBlogPostRequest = new EditBlogPostRequest
                {
                    Id = blogPost.Id,
                    Heading = blogPost.Heading,
                    PageTitle = blogPost.PageTitle,
                    Content = blogPost.Content,
                    Author = blogPost.Author,
                    FeaturedImageUrl = blogPost.FeaturedImageUrl,
                    UrlHandle = blogPost.UrlHandle,
                    ShortDescription = blogPost.ShortDescription,
                    PublishedDate = blogPost.PublishedDate,
                    Visible = blogPost.Visible,
                    Tags = tagsDomainModel.Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString(),
                    }),
                    SelectedTags = blogPost.Tags.Select(x => x.Id.ToString()).ToArray()
                };

                return View(editBlogPostRequest);
            }


            return View(null);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditBlogPostRequest editBlogPostRequest)
        {




            var blogPostDomainModel = new BlogPost
            {
                Id = editBlogPostRequest.Id,
                Heading = editBlogPostRequest.Heading,
                PageTitle = editBlogPostRequest.PageTitle,
                Content = editBlogPostRequest.Content,
                Author = editBlogPostRequest.Author,
                FeaturedImageUrl = editBlogPostRequest.FeaturedImageUrl,
                UrlHandle = editBlogPostRequest.UrlHandle,
                ShortDescription = editBlogPostRequest.ShortDescription,
                PublishedDate = editBlogPostRequest.PublishedDate,
                Visible = editBlogPostRequest.Visible,

            };



            var selectedTags = new List<Tag>();
            foreach (var selectedTag in editBlogPostRequest.SelectedTags)
            {
                if (Guid.TryParse(selectedTag, out var tag))
                {
                    var foundTag = await tagManager.GetAsync(tag);

                    if (foundTag != null)
                    {
                        selectedTags.Add(foundTag);
                    }
                }
            }

            blogPostDomainModel.Tags = selectedTags;



            var updatedBlogPost = await blogPostManager.UpdateBlogPostAsync(blogPostDomainModel);

            if (updatedBlogPost != null)
            {

                return RedirectToAction("List");
            }


            return RedirectToAction("Edit", new { id = editBlogPostRequest.Id });

        }


        [HttpPost]
        public async Task<IActionResult> Delete(EditBlogPostRequest editBlogPostRequest)
        {
            var deletedBlogPost = await blogPostManager.DeleteBlogPostAsync(editBlogPostRequest.Id);

            if (deletedBlogPost != null)
            {
                // show success notification
                return RedirectToAction("List");
            }

            // we will show error notification
            return RedirectToAction("Edit", new { id = editBlogPostRequest.Id });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteListPage(BlogPost blogPost)
        {
            var deletedBlogPost = await blogPostManager.DeleteBlogPostAsync(blogPost.Id);

            if (deletedBlogPost != null)
            {
                // show success notification
                return RedirectToAction("List");
            }

            // we will show error notification
            return RedirectToAction("Edit", new { id = blogPost.Id });
        }




    }
}
