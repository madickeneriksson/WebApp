using WebApp.Models.dto;
using WebApp.Models.dtos;

namespace WebApp.ViewModels
{
    public class ProductDetailsViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<Product> RandomProducts { get; set; }
        public IEnumerable<Tag> ExistingTags { get; set; } = new List<Tag>();
    }
}
