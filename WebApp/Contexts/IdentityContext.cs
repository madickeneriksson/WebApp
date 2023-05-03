
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entities;
using WebApp.Models.Identity;

namespace WebApp.Contexts
{
    public class IdentityContext : IdentityDbContext<AppUser>

    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        }

        public DbSet<AddressEntity> AspNetAddresses { get; set; }
        public DbSet<UserAddressEntity> AspNetUserAddresses { get; set; }

        public DbSet<ProductEntity> Products { get; set; }

        /*
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var roleId = Guid.NewGuid().ToString();
            var userId = Guid.NewGuid().ToString();
            

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                { 
                    Id  = roleId,
                    Name = "SystemAdministrator",
                    NormalizedName = "SYSTEMADMINISTRATOR"
                }
            );

            var passwordHasher = new PasswordHasher<AppUser>();

            builder.Entity<AppUser>().HasData(new AppUser
            {
                Id = userId,
                FirstName= " ",
                LastName= " ",
                UserName = "admin@domain.com",
                Email = "admin@domain.com",
                PasswordHash = passwordHasher.HashPassword(null!, "Bytmig123!"),
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId= roleId,
                UserId= userId,
            });

        }
        */
    }
}
