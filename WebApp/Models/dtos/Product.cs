﻿using WebApp.Models.dtos;

namespace WebApp.Models.dto
{
    public class Product
    {
        public string ArticleNumber { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Rating { get; set; }
        public string? ImageUrl { get; set; }

     //   public ProductCategory ProductCategory { get; set; } = null!;
        public IEnumerable<Tag> Tags { get; set; } = new List<Tag>();
    }
}
