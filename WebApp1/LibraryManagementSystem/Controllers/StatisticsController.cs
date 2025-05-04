using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StatisticsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var statistics = new
            {
                TotalBooks = await _context.Books.CountAsync(),
                TotalAuthors = await _context.Authors.CountAsync(),
                TotalCategories = await _context.Categories.CountAsync(),
                BooksByCategory = await _context.Categories
                    .Select(c => new
                    {
                        CategoryName = c.Name,
                        BookCount = c.Books.Count
                    })
                    .ToListAsync(),
                BooksByAuthor = await _context.Authors
                    .Select(a => new
                    {
                        AuthorName = $"{a.FirstName} {a.LastName}",
                        BookCount = a.Books.Count
                    })
                    .OrderByDescending(x => x.BookCount)
                    .Take(5)
                    .ToListAsync(),
                AverageBookPrice = await _context.Books.AverageAsync(b => b.Price),
                TotalAvailableCopies = await _context.Books.SumAsync(b => b.AvailableCopies)
            };

            return View(statistics);
        }
    }
} 