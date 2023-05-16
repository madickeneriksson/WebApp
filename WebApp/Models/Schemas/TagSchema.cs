using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;

namespace WebApp.Models.Schemas
{
    public class TagSchema
    {
        [Required]
        [MinLength(2, ErrorMessage = "Måste vara minst 2 tecken")]
        public string TagName { get; set; } = null!;

        public static implicit operator TagEntity(TagSchema schema) 
        {
            if(schema != null)
            {
                return new TagEntity
                {
                    TagName = schema.TagName,
                };
            }
            return null!;
        }
    }
}
