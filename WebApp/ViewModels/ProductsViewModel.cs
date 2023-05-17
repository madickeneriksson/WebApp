using WebApp.Models.dto;

namespace WebApp.ViewModels
{
    public class ProductsViewModel
    {
        public string ArticleNumber { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Rating { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }

        public IEnumerable<Product> Products { get; set; } = new List<Product>();

        public bool LoadMore { get; set; } = true;
    }
}
