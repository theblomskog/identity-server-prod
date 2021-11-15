using IdentityServer4AspNetIdentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace User_Management_Service.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //seed data
            UsersSeed(builder);
        }


        private void UsersSeed(ModelBuilder builder)
        {
            var alice = new ApplicationUser
            {
                Id = "1",
                UserName = "alice",
                NormalizedUserName = "ALICE",
                Email = "alice@email.com",
                NormalizedEmail = "alice@email.com".ToUpper(),
                EmailConfirmed = true,
                LockoutEnabled = false
            };
            alice.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(alice, "alice");

            var bob = new ApplicationUser
            {
                Id = "2",
                UserName = "bob",
                NormalizedUserName = "BOB",
                Email = "bob@email.com",
                NormalizedEmail = "bob@email.com".ToUpper(),
                EmailConfirmed = true,
                LockoutEnabled = false
            };
            bob.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(bob, "bob");

            var joe = new ApplicationUser
            {
                Id = "3",
                UserName = "joe",
                NormalizedUserName = "JOE",
                Email = "joe@email.com",
                NormalizedEmail = "joe@email.com".ToUpper(),
                EmailConfirmed = true,
                LockoutEnabled = false
            };
            joe.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(joe, "joe");


            builder.Entity<ApplicationUser>()
                .HasData(alice, bob, joe);


            builder.Entity<IdentityUserClaim<string>>()
                .HasData(
                        new IdentityUserClaim<string> { Id = 1, UserId = "1", ClaimType = "name", ClaimValue = "Alice Smith" },
                        new IdentityUserClaim<string> { Id = 2, UserId = "2", ClaimType = "name", ClaimValue = "Bob Smith" },
                        new IdentityUserClaim<string> { Id = 3, UserId = "3", ClaimType = "name", ClaimValue = "Joe Smith" },

                        new IdentityUserClaim<string> { Id = 4, UserId = "1", ClaimType = "given_name", ClaimValue = "Alice" },
                        new IdentityUserClaim<string> { Id = 5, UserId = "2", ClaimType = "given_name", ClaimValue = "Bob" },
                        new IdentityUserClaim<string> { Id = 6, UserId = "3", ClaimType = "given_name", ClaimValue = "Joe" },

                        new IdentityUserClaim<string> { Id = 7, UserId = "1", ClaimType = "family_name", ClaimValue = "Smith" },
                        new IdentityUserClaim<string> { Id = 8, UserId = "2", ClaimType = "family_name", ClaimValue = "Smith" },
                        new IdentityUserClaim<string> { Id = 9, UserId = "3", ClaimType = "family_name", ClaimValue = "Joe" },

                        //We don't include the email claim here because it is part of the application above. 
                        //including it here will result in duplicate email claims.
                        // new IdentityUserClaim<string> { Id = 10, UserId = "1", ClaimType = "email", ClaimValue = "AliceSmith@email.com" },
                        // new IdentityUserClaim<string> { Id = 11, UserId = "2", ClaimType = "email", ClaimValue = "BobSmith@email.com" },
                        // new IdentityUserClaim<string> { Id = 12, UserId = "3", ClaimType = "email", ClaimValue = "joe@email.com" },

                        new IdentityUserClaim<string> { Id = 13, UserId = "1", ClaimType = "website", ClaimValue = "http://alice.com" },
                        new IdentityUserClaim<string> { Id = 14, UserId = "2", ClaimType = "website", ClaimValue = "http://bob.com" },

                        new IdentityUserClaim<string> { Id = 15, UserId = "1", ClaimType = "address", ClaimValue = @"{ 'street_address': 'One Hacker Way', 'locality': 'Helsingborg', 'postal_code': 12345, 'country': 'Sweden' }" },
                        new IdentityUserClaim<string> { Id = 16, UserId = "2", ClaimType = "address", ClaimValue = @"{ 'street_address': 'Two Cyber Way', 'locality': 'Stockholm', 'postal_code': 23456, 'country': 'Sweden' }" },

                        new IdentityUserClaim<string> { Id = 17, UserId = "1", ClaimType = "employmentid", ClaimValue = "1234" },
                        new IdentityUserClaim<string> { Id = 18, UserId = "2", ClaimType = "employmentid", ClaimValue = "1235" },
                        new IdentityUserClaim<string> { Id = 19, UserId = "3", ClaimType = "employmentid", ClaimValue = "1236" },

                        new IdentityUserClaim<string> { Id = 20, UserId = "1", ClaimType = "employeetype", ClaimValue = "employee" },
                        new IdentityUserClaim<string> { Id = 21, UserId = "2", ClaimType = "employeetype", ClaimValue = "consultant" },
                        new IdentityUserClaim<string> { Id = 22, UserId = "3", ClaimType = "employeetype", ClaimValue = "employee" },

                        new IdentityUserClaim<string> { Id = 23, UserId = "1", ClaimType = "admin", ClaimValue = "yes" },

                        new IdentityUserClaim<string> { Id = 24, UserId = "3", ClaimType = "claim_idresource1", ClaimValue = "id claim rocks!" },
                        new IdentityUserClaim<string> { Id = 25, UserId = "3", ClaimType = "claim_apiresource1", ClaimValue = "apiResource1 claim rocks!" },
                        new IdentityUserClaim<string> { Id = 26, UserId = "3", ClaimType = "claim_apiresource2", ClaimValue = "apiResource2 claim rocks!" },
                        new IdentityUserClaim<string> { Id = 27, UserId = "3", ClaimType = "claim_apiscope1", ClaimValue = "apiScope1 claim rocks!" },

                        new IdentityUserClaim<string> { Id = 28, UserId = "1", ClaimType = "creditlimit", ClaimValue = "10000" },
                        new IdentityUserClaim<string> { Id = 29, UserId = "2", ClaimType = "creditlimit", ClaimValue = "20000" },
                        new IdentityUserClaim<string> { Id = 30, UserId = "3", ClaimType = "creditlimit", ClaimValue = "30000" },

                        new IdentityUserClaim<string> { Id = 31, UserId = "1", ClaimType = "paymentaccess", ClaimValue = "read" },
                        new IdentityUserClaim<string> { Id = 32, UserId = "2", ClaimType = "paymentaccess", ClaimValue = "read:write" },
                        new IdentityUserClaim<string> { Id = 33, UserId = "3", ClaimType = "paymentaccess", ClaimValue = "read:write" }

                );
        }
    }
}
