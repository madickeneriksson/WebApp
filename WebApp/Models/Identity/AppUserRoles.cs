namespace WebApp.Models.Identity
{
    public class AppUserRoles
    {
        public AppUser User { get; set; } = null!;
        public IList<string> Roles { get; set; } = null!;

    }
}
