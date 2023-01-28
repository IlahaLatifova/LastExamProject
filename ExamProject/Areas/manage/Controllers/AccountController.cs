using ExamProject.Models;
using ExamProject.ViewModels.AppUserViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExamProject.Areas.manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signinManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signinManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signinManager = signinManager;
            _roleManager = roleManager;
        }


        /* public async Task<IActionResult> CreateRole()
         {
             IdentityRole role1 = new IdentityRole("Admin");
             IdentityRole role2 = new IdentityRole("User");
             await _roleManager.CreateAsync(role1);
              await _roleManager.CreateAsync(role2);
             return Ok("Bu defe yuz faiz Yarandi");
         }*/
       /* public async Task<IActionResult> AdminRegister()
        {
            AppUser admin = new AppUser()
            {
                FullName = "Admin Adminov",
                UserName = "Admin"
            };
            IdentityResult result = await _userManager.CreateAsync(admin, "admiN1902@");
            await _userManager.AddToRoleAsync(admin, "Admin");
            return Ok(result);
        }*/

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login userLog)
        {
            AppUser user = await _userManager.FindByNameAsync(userLog.UserName);
            if(user is null)
            {
                ModelState.AddModelError("", "Invalid UserName or Password!!!");
                return View(userLog);
            }
            if(userLog.Password is null)
            {
                ModelState.AddModelError("", "Invalid UserName or Password!!!");
                return View(userLog);
            }
            Microsoft.AspNetCore.Identity.SignInResult result = await _signinManager.PasswordSignInAsync(user, userLog.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Invalid UserName or Password!!!");
                return View(userLog);
            }
            return RedirectToAction("Index", "Dashboard");
        }
        public async Task<IActionResult> Logout()
        {
            await _signinManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
