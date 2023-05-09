using System.ComponentModel.DataAnnotations;
using WebApp.ViewModels;

namespace WebApp.Models.Entities
{
    public class ContacFormEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Company { get; set; }
        public string Message { get; set; } = null!;


        public static implicit operator ContacFormEntity(ContactformViewModel v)
        {
            throw new NotImplementedException();
        }
    }
}
