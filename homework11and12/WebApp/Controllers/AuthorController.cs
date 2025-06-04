using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApp.Models;
using WebApp.Filters;

namespace WebApp.Controllers
{
    public class AuthorController : Controller
    {
        // Use the same authors list from BookController
        private static List<Author> GetAuthors()
        {
            var bookController = new BookController();
            var authorsField = bookController.GetType().GetField("authors", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            return authorsField?.GetValue(bookController) as List<Author> ?? new List<Author>();
        }

        // Index - List all authors
        public IActionResult Index()
        {
            var authors = GetAuthors();
            return View(authors);
        }

        // Details - Show author details
        public IActionResult Details(int id)
        {
            var authors = GetAuthors();
            var author = authors.FirstOrDefault(a => a.AuthorId == id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // Expose authors to other controllers
        public static List<Author> GetAuthorsList()
        {
            return GetAuthors();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                var authors = GetAuthors();
                author.AuthorId = authors.Count > 0 ? authors.Max(a => a.AuthorId) + 1 : 1;
                authors.Add(author);
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        public IActionResult Edit(int id)
        {
            var authors = GetAuthors();
            var author = authors.FirstOrDefault(a => a.AuthorId == id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Author author)
        {
            if (id != author.AuthorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var authors = GetAuthors();
                var existingAuthor = authors.FirstOrDefault(a => a.AuthorId == id);
                if (existingAuthor != null)
                {
                    existingAuthor.FirstName = author.FirstName;
                    existingAuthor.LastName = author.LastName;
                    existingAuthor.BirthDate = author.BirthDate;
                    existingAuthor.Biography = author.Biography;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        public IActionResult Delete(int id)
        {
            var authors = GetAuthors();
            var author = authors.FirstOrDefault(a => a.AuthorId == id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var authors = GetAuthors();
            var author = authors.FirstOrDefault(a => a.AuthorId == id);
            if (author != null)
            {
                authors.Remove(author);
            }
            return RedirectToAction(nameof(Index));
        }
    }
} 