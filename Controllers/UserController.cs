using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JobDirectory.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Insta.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private JobContext _iContext;
        public UserController(JobContext context)
        {
            _iContext = context;
        }
        private User ActiveUser 
        {
            get 
            {
                return _iContext.users.Where(u => u.user_id == HttpContext.Session.GetInt32("user_id")).FirstOrDefault();
            }
        }
        [HttpGet("")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("registeruser")]
        public IActionResult RegisterUser(RegisterUser newuser)
        {
            User CheckEmail = _iContext.users
                .Where(u => u.email == newuser.email)
                .SingleOrDefault();

            if(CheckEmail != null)
            {
                ViewBag.errors = "That email already exists";
                return RedirectToAction("Register");
            }
            if(ModelState.IsValid)
            {
                PasswordHasher<RegisterUser> Hasher = new PasswordHasher<RegisterUser>();
                User newUser = new User
                {
                    user_id = newuser.user_id,
                    name = newuser.name,
                    email = newuser.email,
                    username = newuser.username,
                    password = Hasher.HashPassword(newuser, newuser.password)
                  };
                _iContext.Add(newUser);
                _iContext.SaveChanges();
                return RedirectToAction("");
            }
            else
            {
                return View("Register");
            }
        }

        [HttpPost("loginuser")]
        public IActionResult LoginUser(LoginUser loginUser) 
        {
            User CheckEmail = _iContext.users
                .SingleOrDefault(u => u.email == loginUser.email);
            if(CheckEmail != null)
            {
                var Hasher = new PasswordHasher<User>();
                if(0 != Hasher.VerifyHashedPassword(CheckEmail, CheckEmail.password, loginUser.password))
                {
                    HttpContext.Session.SetInt32("user_id", CheckEmail.user_id);
                    HttpContext.Session.SetString("name", CheckEmail.name);
                    return RedirectToAction("");
                }
                else
                {
                    ViewBag.errors = "Incorrect Password";
                    return View("");
                }
            }
            else
            {
                ViewBag.errors = "Email not registered";
                return View("");
            }
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("");
        }
    }
}