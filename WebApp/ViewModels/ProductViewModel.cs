using WebApp.Models.Entities;
using WebApp.Models.Schemas;

namespace WebApp.ViewModels
{
    public class ProductViewModel
    {
        public string ArticleNumber { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Rating { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }

        public int ProductCategoryId { get; set; }
        public List<string>? Tags { get; set; } = new List<string>();

        public static implicit operator ProductEntity(ProductViewModel viewModel)
        {
            if (viewModel != null)
            {
                return new ProductEntity
                {
                    ArticleNumber = viewModel.ArticleNumber,
                    Name = viewModel.Name,
                    Description = viewModel.Description,
                    Rating = viewModel.Rating,
                    ImageUrl = viewModel.ImageUrl,
                    Price = viewModel.Price,
                    ProductCategoryId = viewModel.ProductCategoryId,
                };
            }
            return null!;
        }
    }
}
