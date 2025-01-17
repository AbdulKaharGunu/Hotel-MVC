using Hotel.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class AccountController : Controller
    {

        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("", "Username and Password are required.");
                return View();
            }

            var (isValid, role) = _authService.ValidateUser(username, password);

            if (isValid)
            {
                // Set Session Variables
                HttpContext.Session.SetString("UserName", username);
                HttpContext.Session.SetString("Role", role);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password.");
                return View();
            }
        }

        // GET: /Account/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }



        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
