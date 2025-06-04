using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Author
        public async Task<IActionResult> Index(string searchString, string sortOrder, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSort"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DOBSort"] = sortOrder == "DOB" ? "dob_desc" : "DOB";
            ViewData["CurrentFilter"] = searchString;

            var authors = from a in _context.Authors
                         .Include(a => a.Books)
                         select a;

            if (!string.IsNullOrEmpty(searchString))
            {
                authors = authors.Where(a => a.FirstName.Contains(searchString) ||
                                          a.LastName.Contains(searchString) ||
                                          a.Biography.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    authors = authors.OrderByDescending(a => a.LastName).ThenByDescending(a => a.FirstName);
                    break;
                case "DOB":
                    authors = authors.OrderBy(a => a.DateOfBirth);
                    break;
                case "dob_desc":
                    authors = authors.OrderByDescending(a => a.DateOfBirth);
                    break;
                default:
                    authors = authors.OrderBy(a => a.LastName).ThenBy(a => a.FirstName);
                    break;
            }

            int pageSize = 10;
            return View(await PaginatedList<Author>.CreateAsync(authors.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Author/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _context.Authors
                .Include(a => a.Books)
                .FirstOrDefaultAsync(m => m.AuthorId == id);

            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // GET: Author/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,DateOfBirth,Biography")] Author author)
        {
            if (ModelState.IsValid)
            {
                _context.Add(author);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: Author/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // POST: Author/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AuthorId,FirstName,LastName,DateOfBirth,Biography")] Author author)
        {
            if (id != author.AuthorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(author);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorExists(author.AuthorId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: Author/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _context.Authors
                .Include(a => a.Books)
                .FirstOrDefaultAsync(m => m.AuthorId == id);

            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // POST: Author/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Check if author has associated books
            var author = await _context.Authors
                .Include(a => a.Books)
                .FirstOrDefaultAsync(m => m.AuthorId == id);

            if (author.Books != null && author.Books.Any())
            {
                ModelState.AddModelError("", "Cannot delete author because they have associated books. Remove the books first.");
                return View(author);
            }

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorExists(int id)
        {
            return _context.Authors.Any(e => e.AuthorId == id);
        }
    }
} 