using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace WebNDTIT01.Controllers
{
    public class LoginController : Controller
    {
         [HttpGet, AllowAnonymous]    
        public IActionResult Index()    
        {    
            return View();    
        } 
    }
}