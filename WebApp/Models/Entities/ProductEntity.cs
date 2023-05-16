﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Models.dto;

namespace WebApp.Models.Entities
{
    public partial class ProductEntity
    {
        [Key]
        public string ArticleNumber { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Rating { get; set; }
        public string? ImageUrl { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public int ProductCategoryId { get; set; }
        public ProductCategoryEntity ProductCategory { get; set; } = null!;

        public ICollection<ProductTagEntity> ProductTags { get; set; } = new HashSet<ProductTagEntity>();

        public static implicit operator Product(ProductEntity productEntity)
        {
            return new Product
            {
                ArticleNumber= productEntity.ArticleNumber,
                Name = productEntity.Name,
                Description = productEntity.Description,
                Rating = productEntity.Rating,
                ImageUrl = productEntity.ImageUrl,
                Price = productEntity.Price,
                ProductCategory = productEntity.ProductCategory,
            };
        }

    }
}
