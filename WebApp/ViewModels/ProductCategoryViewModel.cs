using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;
using WebApp.Models.Schemas;

namespace WebApp.ViewModels
{
    public class ProductCategoryViewModel
    {
        [Required]
        [MinLength(2)]
        public string CategoryName { get; set; } = null!;

        public static implicit operator ProductCategoryEntity(ProductCategoryViewModel viewModel)
        {
            if (viewModel != null)
            {
                return new ProductCategoryEntity
                {
                    CategoryName = viewModel.CategoryName,
                };
            }
            return null!;
        }
    }
}
