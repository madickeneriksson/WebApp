using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;
using WebApp.Models.Schemas;

namespace WebApp.ViewModels
{
    public class ProductTagViewModel
    {
        [Required]
        [MinLength(2, ErrorMessage = "Måste vara minst 2 tecken")]
        public string TagName { get; set; } = null!;

        public static implicit operator TagEntity(ProductTagViewModel viewModel)
        {
            if (viewModel != null)
            {
                return new TagEntity
                {
                    TagName = viewModel.TagName,
                };
            }
            return null!;
        }
    }
}
