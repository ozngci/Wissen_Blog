using Blog.Business.Abstract;
using Blog.DataAccess.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Concrete
{
    public class ImageManager:IImageManager
    {
        private readonly IImageRepository imageRepository;

        public ImageManager(IImageRepository imageRepository)  
        {
            this.imageRepository = imageRepository;
        }

        public virtual async Task<string> UploadAsync(IFormFile file)
        {
            return await imageRepository.UploadAsync(file);
        }
    }
}
