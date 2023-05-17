using Microsoft.AspNetCore.Identity;
using WebApp.Models.dtos;
using WebApp.Models.Entities;

namespace WebApp.Models.Identity
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? CompapanyName { get; set; }
        public string? ImageUrl { get; set; }

        public ICollection<UserAddressEntity> Addresses { get; set; } = new HashSet<UserAddressEntity>();

        public static implicit operator Customer(AppUser user)
        {
            return new Customer
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
        }

    }
}
