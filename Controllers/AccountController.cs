using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
//using WebNDTIT01.services;
using WebNDTIT01.Services;
using Microsoft.AspNetCore.Http;

namespace AccountController.Controllers
{
    public class AccountController : Controller
    {
       // private readonly LDAPUtil _ldapUtil;

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string u, string p)
        {
            if (LDAPUtil.Validate(u, p))
            {
                 var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, u),
                    new Claim(ClaimTypes.GivenName, LDAPUtil.GivenName),
                    new Claim(ClaimTypes.Role, LDAPUtil.Roles[0]),
                    new Claim(ClaimTypes.UserData, LDAPUtil.Description)
                };
              
                var claimsIdentity = new ClaimsIdentity(claims, "Login");
 
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                
                return RedirectToAction("Index", "Home");
            }
            ViewBag.loginmsg = "Login Failed : Invalid username or password";
            return View();
        }
         [HttpGet]  
        public ActionResult AccessDenied()  
            {  
                return View();  
            } 
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
