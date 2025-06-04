using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApp.Models;
using WebApp.Filters;

namespace WebApp.Controllers
{
    public class CategoryController : Controller
    {
        // Use the same categories list from BookController
        private static List<Category> GetCategories()
        {
            var bookController = new BookController();
            var categoriesField = bookController.GetType().GetField("categories", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            return categoriesField?.GetValue(bookController) as List<Category> ?? new List<Category>();
        }

        // Index - List all categories
        public IActionResult Index()
        {
            var categories = GetCategories();
            return View(categories);
        }

        // Details - Show category details
        public IActionResult Details(int id)
        {
            var categories = GetCategories();
            var category = categories.FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // Expose categories to other controllers
        public static List<Category> GetCategoriesList()
        {
            return GetCategories();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                var categories = GetCategories();
                category.CategoryId = categories.Count > 0 ? categories.Max(c => c.CategoryId) + 1 : 1;
                categories.Add(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public IActionResult Edit(int id)
        {
            var categories = GetCategories();
            var category = categories.FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Category category)
        {
            if (id != category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var categories = GetCategories();
                var existingCategory = categories.FirstOrDefault(c => c.CategoryId == id);
                if (existingCategory != null)
                {
                    existingCategory.Name = category.Name;
                    existingCategory.Description = category.Description;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public IActionResult Delete(int id)
        {
            var categories = GetCategories();
            var category = categories.FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var categories = GetCategories();
            var category = categories.FirstOrDefault(c => c.CategoryId == id);
            if (category != null)
            {
                categories.Remove(category);
            }
            return RedirectToAction(nameof(Index));
        }
    }
} 