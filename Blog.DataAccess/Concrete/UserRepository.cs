using Blog.DataAccess.Abstract;
using Blog.DataAccess.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly BlogProjesiDbContext blogProjesiDbContext;

        public UserRepository(BlogProjesiDbContext blogProjesiDbContext)
        {
            this.blogProjesiDbContext = blogProjesiDbContext;
        }
        public async Task<IEnumerable<IdentityUser>> GetAllUser()
        {
            var users= await blogProjesiDbContext.Users.ToListAsync();
            var superAdminUser = await blogProjesiDbContext.Users.FirstOrDefaultAsync(x => x.Email == "superadmin@bloggie.com");

            if (superAdminUser is not null)
            {
                users.Remove(superAdminUser);
            }   

            return users;


        }
    }
}
