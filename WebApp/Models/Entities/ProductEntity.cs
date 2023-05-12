﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Models.dto;

namespace WebApp.Models.Entities
{
    public class ProductEntity
    {
        [Key]
        public string ArticleNumber { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Rating { get; set; }
        public string? Category { get; set; }
        public string? ImageUrl { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public static implicit operator Product(ProductEntity productEntity)
        {
            return new Product
            {
                ArticleNumber = productEntity.ArticleNumber,
                Name = productEntity.Name,
                Description = productEntity.Description,
                Rating = productEntity.Rating,
                Category = productEntity.Category,
                ImageUrl = productEntity.ImageUrl,
            };
        }

    }
}
