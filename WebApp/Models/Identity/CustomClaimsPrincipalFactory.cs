using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace WebApp.Models.Identity
{
    public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<AppUser>
    {
        private readonly UserManager<AppUser> userManager;

        public CustomClaimsPrincipalFactory(UserManager<AppUser> userManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
        {
            this.userManager = userManager;
        }

        //Lägga till en egen claim
        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(AppUser user)
        {
            var claimsIdentity = await base.GenerateClaimsAsync(user);
            //var userProfileEntity = await userManager.GetUserAsync(user.Id);

            claimsIdentity.AddClaim(new Claim("DisplayName", $"{user.FirstName} {user.LastName}"));

            var roles = await UserManager.GetRolesAsync(user);
            foreach (var role in roles) 
            {
             claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role));
            }
            return claimsIdentity;

        }
    }
}
