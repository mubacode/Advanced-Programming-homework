using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class StatisticsController : Controller
    {
        // Reference to static data from other controllers
        private static List<Book> GetBooks()
        {
            var bookController = new BookController();
            var method = bookController.GetType().GetField("books", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            return method?.GetValue(bookController) as List<Book> ?? new List<Book>();
        }

        private static List<Author> GetAuthors()
        {
            return AuthorController.GetAuthorsList();
        }

        private static List<Category> GetCategories()
        {
            return CategoryController.GetCategoriesList();
        }

        public IActionResult Index()
        {
            var books = GetBooks();
            var authors = GetAuthors();
            var categories = GetCategories();

            // Link books to authors and categories
            foreach (var book in books)
            {
                book.Author = authors.FirstOrDefault(a => a.AuthorId == book.AuthorId);
                book.Category = categories.FirstOrDefault(c => c.CategoryId == book.CategoryId);
            }

            // Create statistics view model
            var statistics = new LibraryStatisticsViewModel
            {
                TotalBooks = books.Count,
                TotalAuthors = authors.Count,
                TotalCategories = categories.Count,
                AvailableBooks = books.Sum(b => b.AvailableCopies),
                TotalBookCopies = books.Sum(b => b.TotalCopies),
                BooksPerCategory = categories.Select(c => new CategoryStatistics
                {
                    CategoryName = c.Name,
                    BookCount = books.Count(b => b.CategoryId == c.CategoryId)
                }).OrderByDescending(c => c.BookCount).ToList(),
                BooksPerAuthor = authors.Select(a => new AuthorStatistics
                {
                    AuthorName = a.FullName,
                    BookCount = books.Count(b => b.AuthorId == a.AuthorId)
                }).OrderByDescending(a => a.BookCount).ToList(),
                RecentlyAddedBooks = books.OrderByDescending(b => b.PublicationDate).Take(5).ToList(),
                MostPopularLanguages = books.GroupBy(b => b.Language)
                    .Select(g => new LanguageStatistics
                    {
                        Language = g.Key,
                        BookCount = g.Count()
                    })
                    .OrderByDescending(l => l.BookCount)
                    .Take(5)
                    .ToList()
            };

            return View(statistics);
        }
    }
} 