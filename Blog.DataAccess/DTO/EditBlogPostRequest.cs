﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Blog.DataAccess.DTO
{
    public class EditBlogPostRequest
    {
        public Guid Id { get; set; }

        [Required]
        public string Heading { get; set; }

        [Required]
        public string PageTitle { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        [Required]
        public string FeaturedImageUrl { get; set; }

        [Required]
        public string UrlHandle { get; set; }

        [Required]
        public DateTime PublishedDate { get; set; }

        [Required]
        public string Author { get; set; }

        
        public bool Visible { get; set; }

        // display tags
        [Required]
        public IEnumerable<SelectListItem> Tags { get; set; }

        // collect tag
        public string[] SelectedTags { get; set; } = Array.Empty<string>();
    }
}
