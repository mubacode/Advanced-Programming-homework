using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class SeedController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SeedController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Seed/Books
        public async Task<IActionResult> Books()
        {
            if (_context.Books.Any())
            {
                TempData["Message"] = "Database already has books. Skipping seed operation.";
                return RedirectToAction("Index", "Book");
            }

            var books = GetSampleBooks();
            await _context.Books.AddRangeAsync(books);
            await _context.SaveChangesAsync();

            TempData["Message"] = $"Successfully added {books.Count} books to the database.";
            return RedirectToAction("Index", "Book");
        }

        private List<Book> GetSampleBooks()
        {
            var books = new List<Book>();
            var random = new Random();

            // List of 50 real books with their details
            var bookData = new List<(string Title, string Author, string Category, string Publisher, int PageCount, string Language, decimal Price, int Year, string ISBN, string Description)>
            {
                ("To Kill a Mockingbird", "Harper Lee", "Fiction", "HarperCollins", 336, "English", 12.99m, 1960, "978-0-06-112008-4", "The unforgettable novel of a childhood in a sleepy Southern town and the crisis of conscience that rocked it."),
                ("1984", "George Orwell", "Science Fiction", "Penguin Books", 328, "English", 9.99m, 1949, "978-0-452-28423-4", "A dystopian novel set in a totalitarian regime where government surveillance is omnipresent."),
                ("The Great Gatsby", "F. Scott Fitzgerald", "Fiction", "Scribner", 180, "English", 15.00m, 1925, "978-0-7432-7356-5", "A story of wealth, love, and the American Dream during the Roaring Twenties."),
                ("Pride and Prejudice", "Jane Austen", "Romance", "Penguin Classics", 432, "English", 9.99m, 1813, "978-0-14-143951-8", "A romantic novel following the character development of Elizabeth Bennet."),
                ("The Hobbit", "J.R.R. Tolkien", "Fantasy", "Houghton Mifflin", 366, "English", 14.95m, 1937, "978-0-618-00221-4", "The precursor to The Lord of the Rings about Bilbo Baggins' journey with dwarves to reclaim treasure from a dragon."),
                ("Harry Potter and the Sorcerer's Stone", "J.K. Rowling", "Fantasy", "Scholastic", 309, "English", 24.99m, 1997, "978-0-590-35340-3", "The first book in the Harry Potter series about a young wizard's adventures at Hogwarts School of Witchcraft and Wizardry."),
                ("The Catcher in the Rye", "J.D. Salinger", "Fiction", "Little, Brown and Company", 277, "English", 8.99m, 1951, "978-0-316-76948-0", "A novel about a teenager's experiences in New York City after being expelled from prep school."),
                ("The Lord of the Rings", "J.R.R. Tolkien", "Fantasy", "Houghton Mifflin", 1178, "English", 29.99m, 1954, "978-0-618-57498-5", "An epic high-fantasy novel about the quest to destroy the One Ring."),
                ("One Hundred Years of Solitude", "Gabriel García Márquez", "Magic Realism", "Harper & Row", 417, "English", 16.99m, 1967, "978-0-06-088328-7", "The multi-generational story of the Buendía family in the fictional town of Macondo."),
                ("Animal Farm", "George Orwell", "Political Satire", "Harcourt Brace", 112, "English", 7.99m, 1945, "978-0-452-28424-1", "An allegorical novella reflecting events leading up to the Russian Revolution of 1917."),
                ("Brave New World", "Aldous Huxley", "Science Fiction", "Harper Perennial", 288, "English", 15.99m, 1932, "978-0-06-085052-4", "A dystopian novel set in a futuristic World State of genetically modified citizens."),
                ("The Alchemist", "Paulo Coelho", "Fiction", "HarperOne", 197, "English", 16.99m, 1988, "978-0-06-112241-5", "A philosophical novel about a young Andalusian shepherd's journey to find his treasure in Egypt."),
                ("Crime and Punishment", "Fyodor Dostoevsky", "Psychological Fiction", "Penguin Classics", 671, "English", 18.00m, 1866, "978-0-14-044913-6", "A novel about the mental anguish and moral dilemmas of a poor ex-student who murders a pawnbroker."),
                ("The Odyssey", "Homer", "Epic Poetry", "Penguin Classics", 541, "English", 13.99m, -800, "978-0-14-044911-2", "An ancient Greek epic poem following Odysseus's journey home after the Trojan War."),
                ("Moby-Dick", "Herman Melville", "Adventure", "Penguin Classics", 720, "English", 16.00m, 1851, "978-0-14-243724-7", "The story of Captain Ahab's quest for revenge against the white whale, Moby Dick."),
                ("The Grapes of Wrath", "John Steinbeck", "Historical Fiction", "Penguin Classics", 464, "English", 18.00m, 1939, "978-0-14-303943-3", "A story of the Joad family during the Great Depression and Dust Bowl era."),
                ("War and Peace", "Leo Tolstoy", "Historical Fiction", "Vintage Classics", 1296, "English", 20.00m, 1869, "978-1-4000-7998-8", "A chronicle of Russian society during the Napoleonic era."),
                ("The Divine Comedy", "Dante Alighieri", "Poetry", "Penguin Classics", 798, "English", 21.00m, 1320, "978-0-14-243722-3", "An epic poem depicting the journey through Hell, Purgatory, and Paradise."),
                ("The Brothers Karamazov", "Fyodor Dostoevsky", "Philosophical Fiction", "Farrar, Straus and Giroux", 824, "English", 17.00m, 1880, "978-0-374-52837-9", "A passionate philosophical novel exploring faith, doubt, and reason."),
                ("Wuthering Heights", "Emily Brontë", "Gothic Fiction", "Penguin Classics", 416, "English", 8.00m, 1847, "978-0-14-143955-6", "A novel of passion and revenge set on the Yorkshire moors."),
                ("Don Quixote", "Miguel de Cervantes", "Satire", "Ecco", 992, "English", 18.99m, 1605, "978-0-06-093434-7", "Considered the first modern novel, follows the adventures of a man who believes himself to be a knight."),
                ("Jane Eyre", "Charlotte Brontë", "Gothic Fiction", "Penguin Classics", 532, "English", 9.00m, 1847, "978-0-14-144114-6", "A novel about the life of Jane Eyre, from her childhood to her adult life."),
                ("The Iliad", "Homer", "Epic Poetry", "Penguin Classics", 683, "English", 14.99m, -762, "978-0-14-044592-3", "An ancient Greek epic poem set during the Trojan War."),
                ("Frankenstein", "Mary Shelley", "Gothic Fiction", "Penguin Classics", 273, "English", 9.00m, 1818, "978-0-14-143947-1", "A novel about a scientist who creates a sapient creature in an unorthodox experiment."),
                ("The Count of Monte Cristo", "Alexandre Dumas", "Adventure", "Penguin Classics", 1276, "English", 16.00m, 1844, "978-0-14-044926-6", "An adventure novel about a man wrongfully imprisoned who escapes and seeks revenge."),
                ("Les Misérables", "Victor Hugo", "Historical Fiction", "Penguin Classics", 1232, "English", 16.00m, 1862, "978-0-14-044430-8", "A novel set in early 19th-century France, following the lives of several characters."),
                ("The Picture of Dorian Gray", "Oscar Wilde", "Gothic Fiction", "Penguin Classics", 254, "English", 9.00m, 1890, "978-0-14-043784-3", "A philosophical novel about a man who stays young while his portrait ages."),
                ("Anna Karenina", "Leo Tolstoy", "Realist Fiction", "Penguin Classics", 964, "English", 12.99m, 1877, "978-0-14-044917-4", "A complex novel about an adulterous affair between Anna and Count Vronsky."),
                ("The Adventures of Huckleberry Finn", "Mark Twain", "Adventure", "Penguin Classics", 366, "English", 8.00m, 1884, "978-0-14-243719-3", "A novel about a boy's journey down the Mississippi River with an escaped slave."),
                ("Alice's Adventures in Wonderland", "Lewis Carroll", "Fantasy", "Penguin Classics", 176, "English", 7.00m, 1865, "978-0-14-143976-1", "A novel about a girl who falls through a rabbit hole into a fantasy world."),
                ("The Scarlet Letter", "Nathaniel Hawthorne", "Historical Fiction", "Penguin Classics", 279, "English", 8.00m, 1850, "978-0-14-243818-3", "A novel set in 17th-century Puritan Boston about a woman condemned for adultery."),
                ("The Old Man and the Sea", "Ernest Hemingway", "Fiction", "Scribner", 128, "English", 12.00m, 1952, "978-0-684-80122-3", "A novel about an aging Cuban fisherman's struggle with a giant marlin."),
                ("The Stranger", "Albert Camus", "Philosophical Fiction", "Vintage International", 123, "English", 13.00m, 1942, "978-0-679-72020-1", "A story about an ordinary man who is unwittingly drawn into a murder."),
                ("The Trial", "Franz Kafka", "Absurdist Fiction", "Schocken", 255, "English", 15.00m, 1925, "978-0-8052-0999-5", "A novel about a man arrested and prosecuted by a remote authority without ever learning the crime."),
                ("Things Fall Apart", "Chinua Achebe", "Historical Fiction", "Penguin Books", 209, "English", 14.00m, 1958, "978-0-385-47454-2", "A novel about pre-colonial life in Nigeria and the arrival of Europeans."),
                ("Heart of Darkness", "Joseph Conrad", "Novella", "Penguin Classics", 188, "English", 10.00m, 1899, "978-0-14-018680-8", "A novella about a voyage up the Congo River into the heart of Africa."),
                ("Great Expectations", "Charles Dickens", "Coming-of-age", "Penguin Classics", 544, "English", 9.00m, 1861, "978-0-14-143956-3", "A novel about an orphan named Pip and his journey to becoming a gentleman."),
                ("Slaughterhouse-Five", "Kurt Vonnegut", "Science Fiction", "Dial Press", 275, "English", 16.00m, 1969, "978-0-385-33384-9", "An anti-war novel centered on the bombing of Dresden in World War II."),
                ("Lolita", "Vladimir Nabokov", "Controversial Fiction", "Vintage", 336, "English", 16.00m, 1955, "978-0-679-72316-5", "A novel about a middle-aged professor's obsession with a twelve-year-old girl."),
                ("Invisible Man", "Ralph Ellison", "African American Literature", "Vintage", 581, "English", 16.00m, 1952, "978-0-679-72318-9", "A novel about the journey of an African American man who feels socially invisible."),
                ("The Little Prince", "Antoine de Saint-Exupéry", "Children's Literature", "Mariner Books", 96, "English", 11.00m, 1943, "978-0-15-601219-5", "A poetic tale about a young prince who visits various planets in space."),
                ("The Call of the Wild", "Jack London", "Adventure", "Puffin Books", 160, "English", 5.99m, 1903, "978-0-14-036657-1", "A novel about a dog's journey from domestication to living in the wild."),
                ("Fahrenheit 451", "Ray Bradbury", "Dystopian", "Simon & Schuster", 249, "English", 15.99m, 1953, "978-1-4516-7331-9", "A novel about a future American society where books are outlawed and firemen burn them."),
                ("A Tale of Two Cities", "Charles Dickens", "Historical Fiction", "Penguin Classics", 489, "English", 8.00m, 1859, "978-0-14-143960-0", "A historical novel set in London and Paris before and during the French Revolution."),
                ("The Metamorphosis", "Franz Kafka", "Absurdist Fiction", "Dover Publications", 96, "English", 4.00m, 1915, "978-0-486-29030-1", "A novella about a man who wakes up one morning transformed into a huge insect."),
                ("The Wind in the Willows", "Kenneth Grahame", "Children's Literature", "Puffin Books", 288, "English", 6.99m, 1908, "978-0-14-036664-9", "A novel about the adventures of anthropomorphized animals living by a river."),
                ("Mrs. Dalloway", "Virginia Woolf", "Modernist Fiction", "Harcourt", 194, "English", 15.00m, 1925, "978-0-15-662870-9", "A novel that details a day in the life of Clarissa Dalloway, an upper-class woman in post-World War I England."),
                ("The Sun Also Rises", "Ernest Hemingway", "Modernist Fiction", "Scribner", 251, "English", 17.00m, 1926, "978-0-7432-9733-2", "A novel about American and British expatriates who travel from Paris to the Festival of San Fermín in Pamplona.")
            };

            int bookId = 1;
            
            foreach (var data in bookData)
            {
                // Split the author name into first and last name
                var nameParts = data.Author.Split(' ');
                string firstName = nameParts[0];
                string lastName = nameParts.Length > 1 ? string.Join(" ", nameParts.Skip(1)) : "";
                
                // Create author
                var author = new Author
                {
                    AuthorId = bookId,
                    FirstName = firstName,
                    LastName = lastName,
                    BirthDate = null
                };
                
                // Create category
                var category = new Category
                {
                    CategoryId = bookId,
                    Name = data.Category,
                    Description = $"Books in the {data.Category} category"
                };
                
                // Create book
                var book = new Book
                {
                    BookId = bookId,
                    Title = data.Title,
                    ISBN = data.ISBN,
                    Description = data.Description,
                    Price = data.Price,
                    AvailableCopies = random.Next(1, 10),
                    TotalCopies = random.Next(10, 30),
                    PublicationDate = new DateTime(data.Year, 1, 1),
                    Publisher = data.Publisher,
                    Language = data.Language,
                    PageCount = data.PageCount,
                    Author = author,
                    Category = category
                };
                
                books.Add(book);
                bookId++;
            }
            
            return books;
        }
    }
}