using AspNetProjekt.Data;
using AspNetProjekt.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetProjekt
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            SeedDb(host);
            host.Run();

        }
        static async void SeedDb(IHost host) // Seedar in användare i datorbasen
        {
            using (var scope = host.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<EventDbContext>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<MyUser>>();

                /* MyUser attendee = new MyUser()
                 {
                     FirstName = "testfirstname",
                     LastName = "Testlastname",
                     UserName = "testuser",
                     Email = "test@email.com",
                     PhoneNumber = "123456789"
                 };
                 await userManager.CreateAsync(attendee, "Testuser123!"); // Skapar en attendee med specifikt lösenord.

                 MyUser admin = new MyUser()
                 {
                     FirstName = "adminfirstname",
                     LastName = "adminlastname",
                     UserName = "admin",
                     Email = "admin@email.com",
                     PhoneNumber = "123456789"
                 };
                 await userManager.CreateAsync(admin, "Admin123!");
                
                MyUser organizer = new MyUser()
                {
                    FirstName = "organizerfirstname",
                    LastName = "organizerlastname",
                    UserName = "organizer",
                    Email = "organizer@email.com",
                    PhoneNumber = "123456789"
                };
                //  await userManager.CreateAsync(organizer, "Organizer123!");

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
                await context.AddRangeAsync(events); // Lägger till events i event array.*/

                await context.SaveChangesAsync(); // Sparar allting i datorbasen.
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

    }
}
