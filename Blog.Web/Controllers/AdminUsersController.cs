using Blog.Business.Abstract;
using Blog.Business.Concrete;
using Blog.DataAccess.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminUsersController : Controller
    {
        private readonly IUserManager userManager;
        private readonly UserManager<IdentityUser> userManagerAspNet;

        public AdminUsersController(IUserManager userManager, UserManager<IdentityUser> userManagerAspNet)
        {
            this.userManager = userManager;
            this.userManagerAspNet = userManagerAspNet;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var users = await userManager.GetAllUser();

            var usersViewModel = new UserViewModel();
            usersViewModel.Users = new List<User>();

            foreach (var user in users)
            {
                usersViewModel.Users.Add(new Blog.DataAccess.DTO.User
                {
                    Id = Guid.Parse(user.Id),
                    Username = user.UserName,
                    Email = user.Email

                });
            }

            return View(usersViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel userViewModel)
        {
            var identityUser = new IdentityUser
            {
                UserName = userViewModel.Username,
                Email = userViewModel.Email
            };

            var identityResult = await userManagerAspNet.CreateAsync(identityUser, userViewModel.Password);

            if (identityResult is not null)
            {
                if (identityResult.Succeeded)
                {
                    var roles = new List<String> { "User" };

                    if (userViewModel.AdminRoleCheckbox is true)
                    {
                        roles.Add("Admin");
                    }

                    identityResult = await userManagerAspNet.AddToRolesAsync(identityUser, roles);

                    if (identityResult is not null && identityResult.Succeeded)
                    {
                        return RedirectToAction("List", "AdminUsers");
                    }

                }
            }
            return View(userViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {

            var user = await userManagerAspNet.FindByIdAsync(id.ToString()); 

            if (user != null)
            {
                var identityResult = await userManagerAspNet.DeleteAsync(user);

                if (identityResult is not null && identityResult.Succeeded)
                {
                    return RedirectToAction("List", "AdminUsers");
                }
            }

            return View();
        }
    }
}
