using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Paws.Data
{
    public class AuthDbContext : IdentityDbContext<IdentityUser>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Seed Roles (User, Admin, etc)
            var adminRoleID = "040565cc-28b9-4ad6-8077-5ebfb041dff2";
            var userRoleID = "3558b312-fd7b-4384-be0a-1fbabdfb9ffb";
            var superuserRoleID = "b86b0091-2731-49c7-b49a-2b07e2588286";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN",  
                    Id = adminRoleID,
                    ConcurrencyStamp = adminRoleID
                },

                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER",  
                    Id = userRoleID,
                    ConcurrencyStamp = userRoleID
                },

                new IdentityRole
                {
                    Name = "SuperUser",
                    NormalizedName = "SUPERUSER",
                    Id = superuserRoleID,
                    ConcurrencyStamp = superuserRoleID
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);

            // Seed admin user
            var adminID = "c2d440f0-34a9-4d63-8537-f733489011f4";

            var adminUser = new IdentityUser
            {
                UserName = "hidsaan",
                Email = "hidsaan@gmail.com",
                NormalizedEmail = "hidsaan@gmail.com".ToUpper(),
                NormalizedUserName = "hidsaan".ToUpper(),
                Id = adminID
            };

            adminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(adminUser, "AdminUser@11");

            builder.Entity<IdentityUser>().HasData(adminUser);  

            // Add all roles to admin
            var adminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = userRoleID,
                    UserId = adminID
                },
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleID,
                    UserId = adminID
                },
                new IdentityUserRole<string>
                {
                    RoleId = superuserRoleID,
                    UserId = adminID
                }
            };

            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);  // Use builder.Entity<IdentityUserRole<string>>() for role assignment
        }
    }
}
