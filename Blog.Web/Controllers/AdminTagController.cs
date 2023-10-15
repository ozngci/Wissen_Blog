using AutoMapper;
using Blog.Business.Abstract;
using Blog.DataAccess.Abstract;
using Blog.DataAccess.Concrete;
using Blog.DataAccess.DTO;
using Blog.Entity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminTagController : Controller
    {
        private readonly ITagManager tagManager;
        private readonly IMapper mapper;

        public AdminTagController(ITagManager tagManager, IMapper mapper)
        {
            this.tagManager = tagManager;
            this.mapper = mapper;
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Add")]
        public async Task<IActionResult> Add(AddTagRequest addTagRequest)
        {
            if (ModelState.IsValid==false)
            {
                return View();
            }

            var tag = mapper.Map<Tag>(addTagRequest);
            await tagManager.AddAsync(tag);
            return RedirectToAction("List");
        }


        [HttpGet]
        [ActionName("List")]
        public async Task<IActionResult> List()
        {
            var tags = await tagManager.GetAllAsync();
            return View(tags);
        }

        
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            

            var tag = await tagManager.GetAsync(id);

            if (tag != null)
            {
                var editTagRequest = new EditTagRequest
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    DisplayName = tag.DisplayName
                };



                return View(editTagRequest);
            }

            

            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditTagRequest editTagRequest)
        {
            var tag = new Tag
            {
                Id = editTagRequest.Id,
                Name = editTagRequest.Name,
                DisplayName = editTagRequest.DisplayName
            };



            var updatedTag = await tagManager.UpdateTagAsync(tag);

            if (updatedTag != null)
            {
                return RedirectToAction("List");
             
            }
            else
            {
  
            }

            return RedirectToAction("Edit", new { id = editTagRequest.Id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EditTagRequest editTagRequest)
        {



            var deletedTag = await tagManager.DeleteTagAsync(editTagRequest.Id);

            if (deletedTag != null)
            {

                return RedirectToAction("List");
            }

            return RedirectToAction("Edit", new { id = editTagRequest.Id });
        }
    }
}
