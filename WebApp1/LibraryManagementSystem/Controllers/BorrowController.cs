using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Controllers
{
    public class BorrowController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BorrowController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Borrow
        public async Task<IActionResult> Index(string searchString, string status, string sortOrder, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["DateSort"] = string.IsNullOrEmpty(sortOrder) ? "date_desc" : "";
            ViewData["DueSort"] = sortOrder == "Due" ? "due_desc" : "Due";
            ViewData["StatusSort"] = sortOrder == "Status" ? "status_desc" : "Status";
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentStatus"] = status;

            var borrowRecords = from br in _context.BorrowRecords
                               .Include(br => br.Book)
                               .Include(br => br.User)
                               select br;

            if (!string.IsNullOrEmpty(searchString))
            {
                borrowRecords = borrowRecords.Where(br => 
                    br.Book.Title.Contains(searchString) ||
                    br.User.LastName.Contains(searchString) ||
                    br.User.FirstName.Contains(searchString) ||
                    br.Book.ISBN.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(status))
            {
                if (Enum.TryParse<BorrowStatus>(status, out var borrowStatus))
                {
                    borrowRecords = borrowRecords.Where(br => br.Status == borrowStatus);
                }
            }

            // Check for overdue books and update status
            var today = DateTime.Today;
            foreach (var record in await borrowRecords.Where(br => 
                br.Status == BorrowStatus.Active && br.DueDate < today).ToListAsync())
            {
                record.Status = BorrowStatus.Overdue;
                _context.Update(record);
            }
            await _context.SaveChangesAsync();

            switch (sortOrder)
            {
                case "date_desc":
                    borrowRecords = borrowRecords.OrderByDescending(br => br.BorrowDate);
                    break;
                case "Due":
                    borrowRecords = borrowRecords.OrderBy(br => br.DueDate);
                    break;
                case "due_desc":
                    borrowRecords = borrowRecords.OrderByDescending(br => br.DueDate);
                    break;
                case "Status":
                    borrowRecords = borrowRecords.OrderBy(br => br.Status);
                    break;
                case "status_desc":
                    borrowRecords = borrowRecords.OrderByDescending(br => br.Status);
                    break;
                default:
                    borrowRecords = borrowRecords.OrderBy(br => br.BorrowDate);
                    break;
            }

            int pageSize = 10;
            return View(await PaginatedList<BorrowRecord>.CreateAsync(borrowRecords.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Borrow/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowRecord = await _context.BorrowRecords
                .Include(br => br.Book)
                .Include(br => br.User)
                .FirstOrDefaultAsync(m => m.BorrowRecordId == id);

            if (borrowRecord == null)
            {
                return NotFound();
            }

            return View(borrowRecord);
        }

        // GET: Borrow/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books
                .Where(b => b.AvailableCopies > 0), "BookId", "Title");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email");
            return View();
        }

        // POST: Borrow/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,UserId,DueDate,Notes")] BorrowRecord borrowRecord)
        {
            if (ModelState.IsValid)
            {
                // Check if book is available
                var book = await _context.Books.FindAsync(borrowRecord.BookId);
                if (book.AvailableCopies <= 0)
                {
                    ModelState.AddModelError("BookId", "This book is not available for borrowing.");
                    ViewData["BookId"] = new SelectList(_context.Books
                        .Where(b => b.AvailableCopies > 0), "BookId", "Title");
                    ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email");
                    return View(borrowRecord);
                }

                // Set the borrow date to today
                borrowRecord.BorrowDate = DateTime.Now;
                borrowRecord.Status = BorrowStatus.Active;
                
                // Update available copies
                book.AvailableCopies--;
                _context.Update(book);
                
                _context.Add(borrowRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["BookId"] = new SelectList(_context.Books
                .Where(b => b.AvailableCopies > 0), "BookId", "Title", borrowRecord.BookId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", borrowRecord.UserId);
            return View(borrowRecord);
        }

        // GET: Borrow/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowRecord = await _context.BorrowRecords.FindAsync(id);
            if (borrowRecord == null)
            {
                return NotFound();
            }

            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title", borrowRecord.BookId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", borrowRecord.UserId);
            return View(borrowRecord);
        }

        // POST: Borrow/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BorrowRecordId,BookId,UserId,BorrowDate,DueDate,ReturnDate,Status,Notes")] BorrowRecord borrowRecord)
        {
            if (id != borrowRecord.BorrowRecordId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(borrowRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BorrowRecordExists(borrowRecord.BorrowRecordId))
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
            
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title", borrowRecord.BookId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", borrowRecord.UserId);
            return View(borrowRecord);
        }

        // GET: Borrow/Return/5
        public async Task<IActionResult> Return(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowRecord = await _context.BorrowRecords
                .Include(br => br.Book)
                .Include(br => br.User)
                .FirstOrDefaultAsync(m => m.BorrowRecordId == id);

            if (borrowRecord == null)
            {
                return NotFound();
            }

            return View(borrowRecord);
        }

        // POST: Borrow/Return/5
        [HttpPost, ActionName("Return")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReturnConfirmed(int id)
        {
            var borrowRecord = await _context.BorrowRecords
                .Include(br => br.Book)
                .FirstOrDefaultAsync(m => m.BorrowRecordId == id);
            
            if (borrowRecord == null)
            {
                return NotFound();
            }

            // Update borrow record
            borrowRecord.ReturnDate = DateTime.Now;
            borrowRecord.Status = BorrowStatus.Returned;
            _context.Update(borrowRecord);

            // Update book availability
            var book = borrowRecord.Book;
            book.AvailableCopies++;
            _context.Update(book);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Borrow/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowRecord = await _context.BorrowRecords
                .Include(br => br.Book)
                .Include(br => br.User)
                .FirstOrDefaultAsync(m => m.BorrowRecordId == id);

            if (borrowRecord == null)
            {
                return NotFound();
            }

            return View(borrowRecord);
        }

        // POST: Borrow/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var borrowRecord = await _context.BorrowRecords.FindAsync(id);
            _context.BorrowRecords.Remove(borrowRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BorrowRecordExists(int id)
        {
            return _context.BorrowRecords.Any(e => e.BorrowRecordId == id);
        }
    }
} 