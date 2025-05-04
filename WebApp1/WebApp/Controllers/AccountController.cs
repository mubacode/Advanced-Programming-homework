using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebApp.Models;
using WebApp.ViewModels;
using WebApp.Extensions;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        // Using the same user list from UserController for demo purposes
        private static readonly List<User> users = GetUsers();

        private static List<User> GetUsers()
        {
            var userController = new UserController();
            var usersField = userController.GetType().GetField("users", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            return usersField?.GetValue(userController) as List<User> ?? new List<User>();
        }

        // GET: Account/Login
        public IActionResult Login(string returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var user = users.FirstOrDefault(u => 
                    u.Email.Equals(model.Email, StringComparison.OrdinalIgnoreCase) && 
                    u.Password == model.Password && 
                    u.IsActive);

                if (user != null)
                {
                    // Store user in session
                    HttpContext.Session.SetObject("CurrentUser", user);
                    
                    // Set success notification
                    TempData["Message"] = $"Welcome back, {user.FullName}!";
                    
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    
                    // Redirect based on role
                    if (user.Role == "Librarian" || user.Role == "Admin")
                    {
                        return RedirectToAction("Index", "Book");
                    }
                    
                    return RedirectToAction("Catalog", "Book");
                }
                
                ModelState.AddModelError("", "Invalid login attempt.");
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        // GET: Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if user with same email already exists
                if (users.Any(u => u.Email.Equals(model.Email, StringComparison.OrdinalIgnoreCase)))
                {
                    ModelState.AddModelError("Email", "This email is already registered.");
                    return View(model);
                }
                
                // Create new user
                var newUser = new User
                {
                    UserId = users.Count > 0 ? users.Max(u => u.UserId) + 1 : 1,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password, // In a real app, this would be hashed
                    IdNumber = model.IdNumber,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    RegistrationDate = DateTime.Now,
                    IsActive = true,
                    Role = "User" // Default role for new users
                };
                
                // Add user to list
                users.Add(newUser);
                
                // Set success notification
                TempData["Message"] = "Registration successful! You can now log in.";
                
                return RedirectToAction("Login");
            }
            
            return View(model);
        }

        // GET: Account/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["Message"] = "You have been successfully logged out.";
            return RedirectToAction("Login");
        }

        // GET: Account/AccessDenied
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
} 