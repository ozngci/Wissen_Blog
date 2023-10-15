using Blog.Business.Abstract;
using Blog.DataAccess.Concrete;
using Blog.DataAccess.DTO;
using Blog.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogPostManager blogPostManager;
        private readonly ITagManager tagManager;

        public HomeController(ILogger<HomeController> logger, IBlogPostManager blogPostManager, ITagManager tagManager)
        {
            _logger = logger;
            this.blogPostManager = blogPostManager;
            this.tagManager = tagManager;
        }

        public async Task<IActionResult> Index()
        {
            // getting all blogs
            var blogPosts = await blogPostManager.GetAllBlogPostAsync();

            // getting all tags
            var tags = await tagManager.GetAllTagAsync();

            var model = new HomeViewModel
            {
                BlogPosts = blogPosts,
                Tags = tags,
                
                
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}