using WebApp.Models.dto;

namespace WebApp.ViewModels
{
    public class ProductsViewModel
    {
        public IEnumerable<Product> Products { get; set; } = new List<Product>();

    }
}
