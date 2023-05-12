using WebApp.Models.dto;

namespace WebApp.ViewModels
{
    public class ProductsViewModel
    {
        public string? Title { get; set; } = "";

        public string? Categorys { get; set; } = "";
        public IEnumerable<Product> Products { get; set; } = new List<Product>();

        public bool LoadMore { get; set; } = true;
    }
}
