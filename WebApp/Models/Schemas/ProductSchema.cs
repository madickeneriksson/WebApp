using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Models.Entities;

namespace WebApp.Models.Schemas
{
    public class ProductSchema
    {
        public string ArticleNumber { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Rating { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }

   //     public int ProductCategoryId { get; set; }
        public List<string>? Tags { get; set; } = new List<string>();

        public static implicit operator ProductEntity(ProductSchema schema)
        {
            if (schema != null)
            {
                return new ProductEntity
                {
                    ArticleNumber = schema.ArticleNumber,
                    Name = schema.Name,
                    Description = schema.Description,
                    Rating = schema.Rating,
                    ImageUrl = schema.ImageUrl,
                    Price = schema.Price,
                    //ProductCategoryId = schema.ProductCategoryId,
                };
            }
            return null!;
        }
    }
}
