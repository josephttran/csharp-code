using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using SodaMachineRazorPages.Data;
using SodaMachineRazorPages.Models;

namespace SodaMachineRazorPages.Pages.AdminRole
{
    public class IndexModel : PageModel
    {
        private readonly string adminRoleName = "Admin";
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public IndexModel(ApplicationDbContext context, 
            IConfiguration configuration, 
            RoleManager<IdentityRole> roleManager, 
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _configuration = configuration;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public List<AdminRoleView> AdminRoleViews { get; set; }

        public async Task OnGet()
        {
            // Role
            if (ModelState.IsValid)
            {
                bool adminRoleExist = await _roleManager.RoleExistsAsync(adminRoleName);

                if (!adminRoleExist)
                {
                    IdentityRole identityRoleAdmin = new IdentityRole
                    {
                        Name = adminRoleName,
                        NormalizedName = adminRoleName.ToUpper()
                    };

                    IdentityResult resultRole = await _roleManager.CreateAsync(identityRoleAdmin);

                    if (!resultRole.Succeeded)
                    {
                        foreach (IdentityError error in resultRole.Errors)
                        {
                            ModelState.AddModelError(" ", error.Description);
                        }
                    }
                }
            }

            // User
            if (ModelState.IsValid)
            {
                var adminRoleEmail = new AdminRoleEmailConfig();
                _configuration.GetSection("AdminRoleEmail").Bind(adminRoleEmail);

                IdentityUser adminUser = _context.Users.FirstOrDefault(user => user.Email == adminRoleEmail.UserFirst);

                if (adminUser == null)
                {
                    string password = adminRoleEmail.UserFirstPassword;
                    IdentityUser identityUser = new IdentityUser
                    {
                        UserName = adminRoleEmail.UserFirst,                   
                        Email = adminRoleEmail.UserFirst,
                        EmailConfirmed = true
                    };

                    IdentityResult resultUser = await _userManager.CreateAsync(identityUser, password);


                    if (!resultUser.Succeeded)
                    {
                        string errorMessage = "";

                        foreach (IdentityError error in resultUser.Errors)
                        {
                            errorMessage = errorMessage + " " + error.Description ;
                        }

                        throw new Exception("Fail create user: " + errorMessage);
                    }

                    adminUser = _context.Users.FirstOrDefault(user => user.Email == adminRoleEmail.UserFirst);
                }

                string userId = adminUser.Id;

                IdentityRole identityRole = _context.Roles.FirstOrDefault(role => role.Name == adminRoleName);
                string adminRoleId = identityRole.Id;

                IdentityUserRole<string> identityUserRole = _context.UserRoles.FirstOrDefault(userRole =>
                    userRole.UserId == userId &&
                    userRole.RoleId == adminRoleId
                );

                bool isUserInAdminRole = await _userManager.IsInRoleAsync(adminUser, adminRoleName);

                if (!isUserInAdminRole)
                {
                    await _userManager.AddToRoleAsync(adminUser, adminRoleName);
                }
            }

            var users = await _userManager.GetUsersInRoleAsync(adminRoleName);
            
            AdminRoleViews = users.Select(user => new AdminRoleView { Email = user.Email, RoleName = adminRoleName }).ToList();
        }
    }
}
