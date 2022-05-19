using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Restaurant.Services.Identity.DbContexts;
using Restaurant.Services.Identity.Models;
using System.Security.Claims;

namespace Restaurant.Services.Identity.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db, UserManager<ApplicationUser> userManager,
                              RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public void Intialize()
        {
            if (_roleManager.FindByIdAsync(Constants.Admin).Result == null)
            {
                _roleManager.CreateAsync(new IdentityRole(Constants.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(Constants.Customer)).GetAwaiter().GetResult();
            }
            else return;

            ApplicationUser adminUser = new ApplicationUser()
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "1232324345",
                FirstName ="Mike",
                LastName = "Garcia"
            };
           var res = _userManager.CreateAsync(adminUser, "Admin123!").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(adminUser, Constants.Admin).GetAwaiter().GetResult();

            var temp =_userManager.AddClaimsAsync(adminUser, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, adminUser.FirstName + " " + adminUser.LastName),
                 new Claim(JwtClaimTypes.GivenName, adminUser.FirstName),
                 new Claim(JwtClaimTypes.FamilyName, adminUser.LastName),
                new Claim(JwtClaimTypes.Role, Constants.Admin)
            }).Result;

            ApplicationUser customerUser = new ApplicationUser()
            {
                UserName = "customer1@gmail.com",
                Email = "customer1@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "1232324345",
                FirstName = "Esme",
                LastName = "Alonso"
            };
            _userManager.CreateAsync(customerUser, "Esme123!").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(customerUser, Constants.Customer).GetAwaiter().GetResult();

            var temp2 = _userManager.AddClaimsAsync(customerUser, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, customerUser.FirstName + " " + customerUser.LastName),
                 new Claim(JwtClaimTypes.GivenName, customerUser.FirstName),
                 new Claim(JwtClaimTypes.FamilyName, customerUser.LastName),
                new Claim(JwtClaimTypes.Role, Constants.Customer)
            }).Result;
        }
    }
}
