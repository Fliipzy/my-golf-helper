using MyGolfHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGolfHelper.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MyGolfHelperDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return; // Already Seeded
            }
            
            var users = new User[]
            {
                new User() { 
                    Username = "Fliipzy", 
                    Password = "$2y$12$0yOnmdU47TI06cITRlHdkuRFBbTNY1MUlRIyPqraWjZjArLuK/p5G", 
                    Information = new UserInformation {
                        FirstName = "Frederik",
                        LastName = "Lundbeck Jørgensen",
                        Email = "Frederiklundbeck@live.dk",
                        PhoneNumber = "47365972",
                        BirthDate = new DateTime(1993, 1, 11) 
                    }
                },
                new User() {
                    Username = "KasperBallz",
                    Password = "$2y$12$Zs1jqzHEN4iKfQuvQhgr1eKKC.P57RQMOYWI7iawP1au9lMXrZhFK",
                    Information = new UserInformation {
                        FirstName = "Kasper",
                        LastName = "Boller Vilstrup",
                        Email = "kaspervilstrup@gmail.com",
                        PhoneNumber = "57281988",
                        BirthDate = new DateTime(1989, 12, 24)
                    }
                },
                new User() {
                    Username = "MortenB",
                    Password = "$2y$12$UcCeU70eP450agl7g3FH..zd/D9CYGHnnp.rv03p7UaJ4PE10i6Ri",
                    Information = new UserInformation {
                        FirstName = "Morten",
                        LastName = "Boller Vilstrup",
                        Email = "MortenVilstrup@gmail.com",
                        PhoneNumber = "28472648",
                        BirthDate = new DateTime(1992, 8, 3)
                    }
                },
                new User() {
                    Username = "LudvigW",
                    Password = "$2y$12$gH4PNWttZmwWlLBxlEit/.1SnDTIc.nJM8DY.PgqV3ebObHbtH/Lq",
                    Information = new UserInformation {
                        FirstName = "Ludvig",
                        LastName = "Warrer",
                        Email = "Ludvig239@gmail.com",
                        PhoneNumber = "62577379",
                        BirthDate = new DateTime(1996, 9, 18)
                    }
                }
            };

            foreach (var user in users)
            {
                context.Users.Add(user);
            }
            context.SaveChanges();

            var roles = new Role[]
            {
                new Role() { Type = RoleType.ADMIN },
                new Role() { Type = RoleType.MODERATOR },
                new Role() { Type = RoleType.USER }
            };

            foreach (var role in roles)
            {
                context.Roles.Add(role);
            }
            context.SaveChanges();

            var userRoles = new UserRole[]
            {
                new UserRole() { UserId = 1, RoleId = 1 },
                new UserRole() { UserId = 1, RoleId = 2 },
                new UserRole() { UserId = 2, RoleId = 3 },
                new UserRole() { UserId = 3, RoleId = 3 },
                new UserRole() { UserId = 4, RoleId = 3 }
            };

            foreach (var userRole in userRoles)
            {
                context.UserRoles.Add(userRole);
            }
            context.SaveChanges();
            
        }
    }
}
