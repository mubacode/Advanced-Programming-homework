using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApp.Models;
using WebApp.ViewModels;
using WebApp.Filters;

namespace WebApp.Controllers
{
    [TypeFilter(typeof(LibrarianAuthorizationFilter))]
    public class LoanController : Controller
    {
        // Using the same borrow records from UserController for demo purposes
        private static List<BorrowRecord> borrowRecords = GetBorrowRecords();

        // Using the same users from UserController for demo purposes
        private static List<User> users = GetUsers();

        // Using the same books from BookController for demo purposes
        private static List<Book> books = GetBooks();

        private static List<BorrowRecord> GetBorrowRecords()
        {
            var userController = new UserController();
            var recordsField = userController.GetType().GetField("borrowRecords", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            return recordsField?.GetValue(userController) as List<BorrowRecord> ?? new List<BorrowRecord>();
        }

        private static List<User> GetUsers()
        {
            var userController = new UserController();
            var usersField = userController.GetType().GetField("users", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            return usersField?.GetValue(userController) as List<User> ?? new List<User>();
        }

        private static List<Book> GetBooks()
        {
            var bookController = new BookController();
            var booksField = bookController.GetType().GetField("books", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            return booksField?.GetValue(bookController) as List<Book> ?? new List<Book>();
        }

        // GET: Loan
        public IActionResult Index(string searchTerm = null)
        {
            IEnumerable<BorrowRecord> records = borrowRecords;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                // Search by book title, user, or borrow ID
                records = records.Where(br =>
                    br.BorrowRecordId.ToString().Contains(searchTerm) ||
                    books.FirstOrDefault(b => b.BookId == br.BookId)?.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) == true ||
                    users.FirstOrDefault(u => u.UserId == br.UserId)?.FullName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) == true
                );
                ViewBag.SearchTerm = searchTerm;
            }

            var loanRecords = records.Select(br => new LoanViewModel
            {
                BorrowRecordId = br.BorrowRecordId,
                Book = books.FirstOrDefault(b => b.BookId == br.BookId),
                User = users.FirstOrDefault(u => u.UserId == br.UserId),
                BorrowDate = br.BorrowDate,
                DueDate = br.DueDate,
                ReturnDate = br.ReturnDate,
                IsReturned = br.IsReturned,
                IsOverdue = br.IsOverdue,
                Notes = br.Notes
            }).ToList();

            return View(loanRecords);
        }

        // GET: Loan/Create
        public IActionResult Create()
        {
            ViewBag.Books = books.Where(b => b.AvailableCopies > 0).ToList();
            ViewBag.Users = users.Where(u => u.IsActive).ToList();

            var borrowViewModel = new LoanFormViewModel
            {
                BorrowDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(14)
            };

            return View(borrowViewModel);
        }

        // POST: Loan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LoanFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var book = books.FirstOrDefault(b => b.BookId == model.BookId);

                if (book == null || book.AvailableCopies <= 0)
                {
                    ModelState.AddModelError("", "This book is not available for borrowing.");
                    ViewBag.Books = books.Where(b => b.AvailableCopies > 0).ToList();
                    ViewBag.Users = users.Where(u => u.IsActive).ToList();
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

                TempData["Message"] = $"Book successfully loaned to {users.FirstOrDefault(u => u.UserId == model.UserId)?.FullName}.";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Books = books.Where(b => b.AvailableCopies > 0).ToList();
            ViewBag.Users = users.Where(u => u.IsActive).ToList();
            return View(model);
        }

        // GET: Loan/Return/5
        public IActionResult Return(int id)
        {
            var borrowRecord = borrowRecords.FirstOrDefault(br => br.BorrowRecordId == id);
            if (borrowRecord == null)
            {
                return NotFound();
            }

            var book = books.FirstOrDefault(b => b.BookId == borrowRecord.BookId);
            var user = users.FirstOrDefault(u => u.UserId == borrowRecord.UserId);

            var returnViewModel = new ReturnBookViewModel
            {
                BorrowRecordId = borrowRecord.BorrowRecordId,
                BookTitle = book?.Title,
                UserName = user?.FullName,
                BorrowDate = borrowRecord.BorrowDate,
                DueDate = borrowRecord.DueDate,
                ReturnDate = DateTime.Now,
                Notes = borrowRecord.Notes
            };

            return View(returnViewModel);
        }

        // POST: Loan/Return/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Return(ReturnBookViewModel model)
        {
            if (ModelState.IsValid)
            {
                var borrowRecord = borrowRecords.FirstOrDefault(br => br.BorrowRecordId == model.BorrowRecordId);
                if (borrowRecord == null)
                {
                    return NotFound();
                }

                // Mark as returned
                borrowRecord.ReturnDate = model.ReturnDate;
                borrowRecord.Notes = model.Notes;

                // Update book availability
                var book = books.FirstOrDefault(b => b.BookId == borrowRecord.BookId);
                if (book != null)
                {
                    book.AvailableCopies++;
                }

                TempData["Message"] = $"Book successfully returned.";
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
} 