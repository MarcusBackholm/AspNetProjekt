using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AspNetProjekt.Models;
using System;
using System.Threading.Tasks;


namespace AspNetProjekt.Data
{
    public class EventDbContext : IdentityDbContext
    {
        public EventDbContext(DbContextOptions<EventDbContext> options)
            : base(options)
        {
        }

        public DbSet<Events> Event { get; set; }
        public DbSet<MyUser> MyUser { get; set; }

        public async Task resetDb(UserManager<MyUser> userManager, RoleManager<IdentityRole> roleManager) // Seedar in användare i datorbasen
        {
            await Database.EnsureDeletedAsync();
            await Database.EnsureCreatedAsync();

            await roleManager.CreateAsync(new IdentityRole("admin")); //Skapar användar roller.
            await roleManager.CreateAsync(new IdentityRole("organizer"));
            await roleManager.CreateAsync(new IdentityRole("user"));

            MyUser attendee = new MyUser()
            {
                FirstName = "testfirstname",
                LastName = "Testlastname",
                UserName = "testuser",
                Email = "test@email.com",
                PhoneNumber = "123456789"
            };
            await userManager.CreateAsync(attendee, "Testuser123!"); // Skapar en attendee med specifikt lösenord.
            await userManager.AddToRoleAsync(attendee, "user");

            MyUser admin = new MyUser()
            {
                FirstName = "adminfirstname",
                LastName = "adminlastname",
                UserName = "admin",
                Email = "admin@email.com",
                PhoneNumber = "123456789"
            };
            await userManager.CreateAsync(admin, "Admin123!");
            await userManager.AddToRoleAsync(admin, "admin");

            MyUser organizer = new MyUser()
            {
                FirstName = "organizerfirstname",
                LastName = "organizerlastname",
                UserName = "organizer",
                Email = "organizer@email.com",
                PhoneNumber = "123456789"
            };
            await userManager.CreateAsync(organizer, "Organizer123!");
            await userManager.AddToRoleAsync(organizer, "organizer");

            Events[] events = new Events[] {
                new Events(){

                    Description = "Gitarrer och bas",
                    Title = "Musik",
                    Place = "Malmstorg 2B",
                    Date = DateTime.Now.AddDays(60),
                    Spots_Available = 100,
                    Organizer = organizer
                },
                new Events()
                {
                    Description = "snus är bra",
                    Title = "tobak",
                    Place = "hejdågatan 13",
                    Date = DateTime.Now.AddDays(100),
                    Spots_Available = 1000,
                    Organizer = organizer
                },

                };
            await AddRangeAsync(events); // Lägger till events i event array.

            await SaveChangesAsync(); // Sparar allting i datorbasen.
        }

    }
}
