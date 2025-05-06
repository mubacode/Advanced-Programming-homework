using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApp.Models;
using WebApp.ViewModels;
using WebApp.Extensions;
using Microsoft.AspNetCore.Authorization;
using WebApp.Filters;

namespace WebApp.Controllers
{
    public class UserController : Controller
    {
        // List of users and borrow records (static sample data)
        private static List<User> users = new List<User>
        {
            new User
            {
                UserId = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Password = "password123", // In a real app, this would be hashed
                PhoneNumber = "555-123-4567",
                Address = "123 Main St, Anytown, USA",
                RegistrationDate = DateTime.Now.AddMonths(-6),
                IsActive = true,
                Role = "User"
            },
            new User
            {
                UserId = 2,
                FirstName = "Jane",
                LastName = "Smith",
                Email = "jane.smith@example.com",
                Password = "password456", // In a real app, this would be hashed
                PhoneNumber = "555-987-6543",
                Address = "456 Oak Ave, Somewhere, USA",
                RegistrationDate = DateTime.Now.AddMonths(-3),
                IsActive = true,
                Role = "Librarian"
            },
            new User
            {
                UserId = 3,
                FirstName = "Admin",
                LastName = "User",
                Email = "admin@library.com",
                Password = "adminpass", // In a real app, this would be hashed
                PhoneNumber = "555-111-2222",
                Address = "789 Library Blvd, Bookville, USA",
                RegistrationDate = DateTime.Now.AddYears(-1),
                IsActive = true,
                Role = "Admin"
            }
        };

        // Static list of borrow records
        private static List<BorrowRecord> borrowRecords = new List<BorrowRecord>();

        // Get books from BookController
        private static List<Book> GetBooks()
        {
            var bookController = new BookController();
            var method = bookController.GetType().GetField("books", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            return method?.GetValue(bookController) as List<Book> ?? new List<Book>();
        }

        // Index - List all users
        public IActionResult Index()
        {
            return View(users);
        }

        // Details - Show user details
        public IActionResult Details(int id)
        {
            var user = users.FirstOrDefault(u => u.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            // Get user's borrow records
            user.BorrowRecords = borrowRecords.Where(br => br.UserId == id).ToList();
            
            return View(user);
        }

        // Create - Show form to create a new user
        public IActionResult Create()
        {
            return View();
        }

        // Create - Process form submission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                user.UserId = users.Count > 0 ? users.Max(u => u.UserId) + 1 : 1;
                user.RegistrationDate = DateTime.Now;
                user.IsActive = true;
                users.Add(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // Edit - Show form to edit a user
        public IActionResult Edit(int id)
        {
            var user = users.FirstOrDefault(u => u.UserId == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // Edit - Process form submission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, User user)
        {
            if (id != user.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingUser = users.FirstOrDefault(u => u.UserId == id);
                if (existingUser != null)
                {
                    existingUser.FirstName = user.FirstName;
                    existingUser.LastName = user.LastName;
                    existingUser.Email = user.Email;
                    existingUser.PhoneNumber = user.PhoneNumber;
                    existingUser.Address = user.Address;
                    existingUser.Role = user.Role;
                    existingUser.IsActive = user.IsActive;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // Delete - Show confirmation page
        public IActionResult Delete(int id)
        {
            var user = users.FirstOrDefault(u => u.UserId == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // Delete - Process deletion
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = users.FirstOrDefault(u => u.UserId == id);
            if (user != null)
            {
                users.Remove(user);
            }
            return RedirectToAction(nameof(Index));
        }

        // BorrowBook - Show form to borrow a book (Librarian only)
        [TypeFilter(typeof(LibrarianAuthorizationFilter))]
        public IActionResult BorrowBook(int? userId)
        {
            var books = GetBooks().Where(b => b.AvailableCopies > 0).ToList();
            
            ViewBag.Books = books;
            ViewBag.Users = users;
            
            var borrowViewModel = new BorrowBookViewModel
            {
                UserId = userId ?? 0,
                BorrowDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(14)
            };
            
            return View(borrowViewModel);
        }

        // BorrowBook - Process book borrowing (Librarian only)
        [HttpPost]
        [ValidateAntiForgeryToken]
        [TypeFilter(typeof(LibrarianAuthorizationFilter))]
        public IActionResult BorrowBook(BorrowBookViewModel model)
        {
            if (ModelState.IsValid)
            {
                var books = GetBooks();
                var book = books.FirstOrDefault(b => b.BookId == model.BookId);
                
                if (book == null || book.AvailableCopies <= 0)
                {
                    ModelState.AddModelError("", "This book is not available for borrowing.");
                    ViewBag.Books = books.Where(b => b.AvailableCopies > 0).ToList();
                    ViewBag.Users = users;
                    return View(model);
                }
                
                var borrowRecord = new BorrowRecord
                {
                    BorrowRecordId = borrowRecords.Count > 0 ? borrowRecords.Max(br => br.BorrowRecordId) + 1 : 1,
                    BookId = model.BookId,
                    UserId = model.UserId,
                    BorrowDate = model.BorrowDate,
                    DueDate = model.DueDate,
                    Notes = model.Notes
                };
                
                // Update book availability
                book.AvailableCopies--;
                
                borrowRecords.Add(borrowRecord);
                
                return RedirectToAction("Details", new { id = model.UserId });
            }
            
            ViewBag.Books = GetBooks().Where(b => b.AvailableCopies > 0).ToList();
            ViewBag.Users = users;
            return View(model);
        }

        // ReturnBook - Process book return (Librarian only)
        [TypeFilter(typeof(LibrarianAuthorizationFilter))]
        public IActionResult ReturnBook(int id)
        {
            var borrowRecord = borrowRecords.FirstOrDefault(br => br.BorrowRecordId == id);
            if (borrowRecord == null)
            {
                return NotFound();
            }
            
            // Mark as returned
            borrowRecord.ReturnDate = DateTime.Now;
            
            // Update book availability
            var books = GetBooks();
            var book = books.FirstOrDefault(b => b.BookId == borrowRecord.BookId);
            if (book != null)
            {
                book.AvailableCopies++;
            }
            
            return RedirectToAction("Details", new { id = borrowRecord.UserId });
        }
    }
} 