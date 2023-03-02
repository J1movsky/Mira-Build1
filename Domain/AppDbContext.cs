using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Mira.Domain.Entites;
using System.Data.SqlTypes;

namespace Mira.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TextField> TextFields { get; set; }
        public DbSet<ServiceItem> ServiceItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "1",
                Name = "admin",
                NormalizedName= "ADMIN",
            });


            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id= "2",
                UserName= "admin",
                NormalizedUserName= "ADMIN",
                Email = "my@mail.com",
                NormalizedEmail = "ME@MAIL.COM",
                EmailConfirmed= false,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId= "1",
                UserId= "2"

            });

            builder.Entity<TextField>().HasData(new TextField 
            {
                Id = 4,
                CodeWord = "PageIndex",
                Title = "Главная"
            });

            builder.Entity<TextField>().HasData(new TextField
            {
                Id = 5,
                CodeWord = "PageServeces",
                Title = "Наши услуги"
            });

            builder.Entity<TextField>().HasData(new TextField 
            {
                Id = 6,
                CodeWord = "PageContacts",
                Title = "Контакты"
            });

        }

    }
}
