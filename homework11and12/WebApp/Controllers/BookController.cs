using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApp.Models;
using WebApp.Filters;
using WebApp.Extensions;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class BookController : Controller
    {
        // For now, use a static list as sample data (this would be replaced with a database in a real application)
        private static List<Book> books = GetInitialBooks();
        
        // Static lists for authors and categories
        private static List<Author> authors = new List<Author>
        {
            new Author { AuthorId = 1, FirstName = "Harper", LastName = "Lee", BirthDate = new DateTime(1926, 4, 28) },
            new Author { AuthorId = 2, FirstName = "George", LastName = "Orwell", BirthDate = new DateTime(1903, 6, 25) },
            new Author { AuthorId = 3, FirstName = "F. Scott", LastName = "Fitzgerald", BirthDate = new DateTime(1896, 9, 24) },
            new Author { AuthorId = 4, FirstName = "Jane", LastName = "Austen", BirthDate = new DateTime(1775, 12, 16) },
            new Author { AuthorId = 5, FirstName = "J.R.R.", LastName = "Tolkien", BirthDate = new DateTime(1892, 1, 3) },
            new Author { AuthorId = 6, FirstName = "J.K.", LastName = "Rowling", BirthDate = new DateTime(1965, 7, 31) },
            new Author { AuthorId = 7, FirstName = "J.D.", LastName = "Salinger", BirthDate = new DateTime(1919, 1, 1) },
            new Author { AuthorId = 8, FirstName = "Gabriel", LastName = "García Márquez", BirthDate = new DateTime(1927, 3, 6) },
            new Author { AuthorId = 9, FirstName = "Aldous", LastName = "Huxley", BirthDate = new DateTime(1894, 7, 26) },
            new Author { AuthorId = 10, FirstName = "Paulo", LastName = "Coelho", BirthDate = new DateTime(1947, 8, 24) },
            new Author { AuthorId = 11, FirstName = "Fyodor", LastName = "Dostoevsky", BirthDate = new DateTime(1821, 11, 11) },
            new Author { AuthorId = 12, FirstName = "Homer", LastName = "", BirthDate = null },
            new Author { AuthorId = 13, FirstName = "Herman", LastName = "Melville", BirthDate = new DateTime(1819, 8, 1) },
            new Author { AuthorId = 14, FirstName = "John", LastName = "Steinbeck", BirthDate = new DateTime(1902, 2, 27) },
            new Author { AuthorId = 15, FirstName = "Leo", LastName = "Tolstoy", BirthDate = new DateTime(1828, 9, 9) },
            new Author { AuthorId = 16, FirstName = "Dante", LastName = "Alighieri", BirthDate = new DateTime(1265, 5, 21) },
            new Author { AuthorId = 17, FirstName = "Emily", LastName = "Brontë", BirthDate = new DateTime(1818, 7, 30) },
            new Author { AuthorId = 18, FirstName = "Miguel", LastName = "de Cervantes", BirthDate = new DateTime(1547, 9, 29) },
            new Author { AuthorId = 19, FirstName = "Charlotte", LastName = "Brontë", BirthDate = new DateTime(1816, 4, 21) },
            new Author { AuthorId = 20, FirstName = "Mary", LastName = "Shelley", BirthDate = new DateTime(1797, 8, 30) }
        };
        
        private static List<Category> categories = new List<Category>
        {
            new Category { CategoryId = 1, Name = "Fiction", Description = "Literary works created from the imagination" },
            new Category { CategoryId = 2, Name = "Science Fiction", Description = "Fiction based on scientific discoveries or advanced technology" },
            new Category { CategoryId = 3, Name = "Romance", Description = "Stories about romantic love relationships" },
            new Category { CategoryId = 4, Name = "Fantasy", Description = "Fiction involving magic and supernatural elements" },
            new Category { CategoryId = 5, Name = "Magic Realism", Description = "Fiction where magical elements appear in otherwise realistic settings" },
            new Category { CategoryId = 6, Name = "Political Satire", Description = "Fiction using satire to criticize politics" },
            new Category { CategoryId = 7, Name = "Philosophical Fiction", Description = "Fiction exploring philosophical concepts" },
            new Category { CategoryId = 8, Name = "Adventure", Description = "Fiction about exciting undertakings involving risk and action" },
            new Category { CategoryId = 9, Name = "Historical Fiction", Description = "Fiction set in the past with historically accurate details" },
            new Category { CategoryId = 10, Name = "Gothic Fiction", Description = "Fiction combining elements of horror and romance" },
            new Category { CategoryId = 11, Name = "Dystopian", Description = "Fiction set in a dark, oppressive society" },
            new Category { CategoryId = 12, Name = "Mystery", Description = "Fiction centered around solving a crime or puzzle" },
            new Category { CategoryId = 13, Name = "Horror", Description = "Fiction intended to frighten, scare, or disgust" },
            new Category { CategoryId = 14, Name = "Thriller", Description = "Fiction characterized by suspense, excitement, and high stakes" },
            new Category { CategoryId = 15, Name = "Biography", Description = "Account of a person's life written by someone else" },
            new Category { CategoryId = 16, Name = "Epic Poetry", Description = "Long narrative poems celebrating heroic deeds" },
            new Category { CategoryId = 17, Name = "Children's Literature", Description = "Books written for children" },
            new Category { CategoryId = 18, Name = "Coming-of-age", Description = "Stories focusing on the growth of a protagonist from youth to adulthood" },
            new Category { CategoryId = 19, Name = "Modernist Fiction", Description = "Literature characterized by a break with traditional forms" },
            new Category { CategoryId = 20, Name = "Classic Literature", Description = "Books that have stood the test of time" }
        };
        
        // Get initial list of books (moved here to make it cleaner)
        private static List<Book> GetInitialBooks()
        {
            var initialBooks = new List<Book>
            {
                new Book
                {
                    BookId = 1,
                    Title = "To Kill a Mockingbird",
                    ISBN = "978-0-06-112008-4",
                    Description = "The unforgettable novel of a childhood in a sleepy Southern town and the crisis of conscience that rocked it.",
                    Price = 12.99m,
                    AvailableCopies = 5,
                    TotalCopies = 10,
                    PublicationDate = new DateTime(1960, 7, 11),
                    Publisher = "HarperCollins",
                    Language = "English",
                    PageCount = 336,
                    AuthorId = 1,
                    CategoryId = 1
                },
                new Book
                {
                    BookId = 2,
                    Title = "1984",
                    ISBN = "978-0-452-28423-4",
                    Description = "A dystopian novel set in a totalitarian regime where government surveillance is omnipresent.",
                    Price = 9.99m,
                    AvailableCopies = 3,
                    TotalCopies = 8,
                    PublicationDate = new DateTime(1949, 6, 8),
                    Publisher = "Penguin Books",
                    Language = "English",
                    PageCount = 328,
                    AuthorId = 2,
                    CategoryId = 2
                },
                new Book
                {
                    BookId = 3,
                    Title = "The Great Gatsby",
                    ISBN = "978-0-7432-7356-5",
                    Description = "A story of wealth, love, and the American Dream during the Roaring Twenties.",
                    Price = 15.00m,
                    AvailableCopies = 7,
                    TotalCopies = 12,
                    PublicationDate = new DateTime(1925, 4, 10),
                    Publisher = "Scribner",
                    Language = "English",
                    PageCount = 180,
                    AuthorId = 3,
                    CategoryId = 1
                },
                new Book
                {
                    BookId = 4,
                    Title = "Pride and Prejudice",
                    ISBN = "978-0-14-143951-8",
                    Description = "A romantic novel following the character development of Elizabeth Bennet.",
                    Price = 9.99m,
                    AvailableCopies = 4,
                    TotalCopies = 9,
                    PublicationDate = new DateTime(1813, 1, 28),
                    Publisher = "Penguin Classics",
                    Language = "English",
                    PageCount = 432,
                    AuthorId = 4,
                    CategoryId = 3
                },
                new Book
                {
                    BookId = 5,
                    Title = "The Hobbit",
                    ISBN = "978-0-618-00221-4",
                    Description = "The precursor to The Lord of the Rings about Bilbo Baggins' journey with dwarves to reclaim treasure from a dragon.",
                    Price = 14.95m,
                    AvailableCopies = 2,
                    TotalCopies = 7,
                    PublicationDate = new DateTime(1937, 9, 21),
                    Publisher = "Houghton Mifflin",
                    Language = "English",
                    PageCount = 366,
                    AuthorId = 5,
                    CategoryId = 4
                },
                new Book
                {
                    BookId = 6,
                    Title = "Harry Potter and the Sorcerer's Stone",
                    ISBN = "978-0-590-35340-3",
                    Description = "The first book in the Harry Potter series about a young wizard's adventures at Hogwarts School of Witchcraft and Wizardry.",
                    Price = 24.99m,
                    AvailableCopies = 6,
                    TotalCopies = 15,
                    PublicationDate = new DateTime(1997, 6, 26),
                    Publisher = "Scholastic",
                    Language = "English",
                    PageCount = 309,
                    AuthorId = 6,
                    CategoryId = 4
                },
                new Book
                {
                    BookId = 7,
                    Title = "The Catcher in the Rye",
                    ISBN = "978-0-316-76948-0",
                    Description = "A novel about a teenager's experiences in New York City after being expelled from prep school.",
                    Price = 8.99m,
                    AvailableCopies = 3,
                    TotalCopies = 10,
                    PublicationDate = new DateTime(1951, 7, 16),
                    Publisher = "Little, Brown and Company",
                    Language = "English",
                    PageCount = 277,
                    AuthorId = 7,
                    CategoryId = 1
                },
                new Book
                {
                    BookId = 8,
                    Title = "The Lord of the Rings",
                    ISBN = "978-0-618-57498-5",
                    Description = "An epic high-fantasy novel about the quest to destroy the One Ring.",
                    Price = 29.99m,
                    AvailableCopies = 4,
                    TotalCopies = 8,
                    PublicationDate = new DateTime(1954, 7, 29),
                    Publisher = "Houghton Mifflin",
                    Language = "English",
                    PageCount = 1178,
                    AuthorId = 5,
                    CategoryId = 4
                },
                new Book
                {
                    BookId = 9,
                    Title = "One Hundred Years of Solitude",
                    ISBN = "978-0-06-088328-7",
                    Description = "The multi-generational story of the Buendía family in the fictional town of Macondo.",
                    Price = 16.99m,
                    AvailableCopies = 5,
                    TotalCopies = 9,
                    PublicationDate = new DateTime(1967, 5, 30),
                    Publisher = "Harper & Row",
                    Language = "English",
                    PageCount = 417,
                    AuthorId = 8,
                    CategoryId = 5
                },
                new Book
                {
                    BookId = 10,
                    Title = "Animal Farm",
                    ISBN = "978-0-452-28424-1",
                    Description = "An allegorical novella reflecting events leading up to the Russian Revolution of 1917.",
                    Price = 7.99m,
                    AvailableCopies = 2,
                    TotalCopies = 12,
                    PublicationDate = new DateTime(1945, 8, 17),
                    Publisher = "Harcourt Brace",
                    Language = "English",
                    PageCount = 112,
                    AuthorId = 2,
                    CategoryId = 6
                },
                new Book
                {
                    BookId = 11,
                    Title = "Brave New World",
                    ISBN = "978-0-06-085052-4",
                    Description = "A dystopian novel set in a futuristic World State of genetically modified citizens.",
                    Price = 15.99m,
                    AvailableCopies = 6,
                    TotalCopies = 11,
                    PublicationDate = new DateTime(1932, 10, 27),
                    Publisher = "Harper Perennial",
                    Language = "English",
                    PageCount = 288,
                    AuthorId = 9,
                    CategoryId = 2
                },
                new Book
                {
                    BookId = 12,
                    Title = "The Alchemist",
                    ISBN = "978-0-06-112241-5",
                    Description = "A philosophical novel about a young Andalusian shepherd's journey to find his treasure in Egypt.",
                    Price = 16.99m,
                    AvailableCopies = 7,
                    TotalCopies = 15,
                    PublicationDate = new DateTime(1988, 1, 1),
                    Publisher = "HarperOne",
                    Language = "English",
                    PageCount = 197,
                    AuthorId = 10,
                    CategoryId = 7
                },
                new Book
                {
                    BookId = 13,
                    Title = "Crime and Punishment",
                    ISBN = "978-0-14-044913-6",
                    Description = "A novel about the mental anguish and moral dilemmas of a poor ex-student who murders a pawnbroker.",
                    Price = 18.00m,
                    AvailableCopies = 3,
                    TotalCopies = 8,
                    PublicationDate = new DateTime(1866, 1, 1),
                    Publisher = "Penguin Classics",
                    Language = "English",
                    PageCount = 671,
                    AuthorId = 2,
                    CategoryId = 7
                },
                new Book
                {
                    BookId = 14,
                    Title = "The Odyssey",
                    ISBN = "978-0-14-044911-2",
                    Description = "An ancient Greek epic poem following Odysseus's journey home after the Trojan War.",
                    Price = 13.99m,
                    AvailableCopies = 5,
                    TotalCopies = 10,
                    PublicationDate = new DateTime(800, 1, 1).AddYears(-1),
                    Publisher = "Penguin Classics",
                    Language = "English",
                    PageCount = 541,
                    AuthorId = 3,
                    CategoryId = 8
                },
                new Book
                {
                    BookId = 15,
                    Title = "Moby-Dick",
                    ISBN = "978-0-14-243724-7",
                    Description = "The story of Captain Ahab's quest for revenge against the white whale, Moby Dick.",
                    Price = 16.00m,
                    AvailableCopies = 4,
                    TotalCopies = 9,
                    PublicationDate = new DateTime(1851, 10, 18),
                    Publisher = "Penguin Classics",
                    Language = "English",
                    PageCount = 720,
                    AuthorId = 4,
                    CategoryId = 8
                },
                new Book
                {
                    BookId = 16,
                    Title = "The Grapes of Wrath",
                    ISBN = "978-0-14-303943-3",
                    Description = "A story of the Joad family during the Great Depression and Dust Bowl era.",
                    Price = 18.00m,
                    AvailableCopies = 3,
                    TotalCopies = 7,
                    PublicationDate = new DateTime(1939, 4, 14),
                    Publisher = "Penguin Classics",
                    Language = "English",
                    PageCount = 464,
                    AuthorId = 5,
                    CategoryId = 9
                },
                new Book
                {
                    BookId = 17,
                    Title = "War and Peace",
                    ISBN = "978-1-4000-7998-8",
                    Description = "A chronicle of Russian society during the Napoleonic era.",
                    Price = 20.00m,
                    AvailableCopies = 2,
                    TotalCopies = 5,
                    PublicationDate = new DateTime(1869, 1, 1),
                    Publisher = "Vintage Classics",
                    Language = "English",
                    PageCount = 1296,
                    AuthorId = 6,
                    CategoryId = 9
                },
                new Book
                {
                    BookId = 18,
                    Title = "The Divine Comedy",
                    ISBN = "978-0-14-243722-3",
                    Description = "An epic poem depicting the journey through Hell, Purgatory, and Paradise.",
                    Price = 21.00m,
                    AvailableCopies = 1,
                    TotalCopies = 6,
                    PublicationDate = new DateTime(1320, 1, 1),
                    Publisher = "Penguin Classics",
                    Language = "English",
                    PageCount = 798,
                    AuthorId = 7,
                    CategoryId = 1
                },
                new Book
                {
                    BookId = 19,
                    Title = "The Brothers Karamazov",
                    ISBN = "978-0-374-52837-9",
                    Description = "A passionate philosophical novel exploring faith, doubt, and reason.",
                    Price = 17.00m,
                    AvailableCopies = 3,
                    TotalCopies = 8,
                    PublicationDate = new DateTime(1880, 11, 1),
                    Publisher = "Farrar, Straus and Giroux",
                    Language = "English",
                    PageCount = 824,
                    AuthorId = 8,
                    CategoryId = 7
                },
                new Book
                {
                    BookId = 20,
                    Title = "Wuthering Heights",
                    ISBN = "978-0-14-143955-6",
                    Description = "A novel of passion and revenge set on the Yorkshire moors.",
                    Price = 8.00m,
                    AvailableCopies = 5,
                    TotalCopies = 10,
                    PublicationDate = new DateTime(1847, 12, 1),
                    Publisher = "Penguin Classics",
                    Language = "English",
                    PageCount = 416,
                    AuthorId = 9,
                    CategoryId = 10
                },
                new Book
                {
                    BookId = 21,
                    Title = "Don Quixote",
                    ISBN = "978-0-06-093434-7",
                    Description = "Considered the first modern novel, follows the adventures of a man who believes himself to be a knight.",
                    Price = 18.99m,
                    AvailableCopies = 4,
                    TotalCopies = 9,
                    PublicationDate = new DateTime(1605, 1, 16),
                    Publisher = "Ecco",
                    Language = "English",
                    PageCount = 992,
                    AuthorId = 10,
                    CategoryId = 8
                },
                new Book
                {
                    BookId = 22,
                    Title = "Jane Eyre",
                    ISBN = "978-0-14-144114-6",
                    Description = "A novel about the life of Jane Eyre, from her childhood to her adult life.",
                    Price = 9.00m,
                    AvailableCopies = 6,
                    TotalCopies = 12,
                    PublicationDate = new DateTime(1847, 10, 16),
                    Publisher = "Penguin Classics",
                    Language = "English",
                    PageCount = 532,
                    AuthorId = 1,
                    CategoryId = 10
                },
                new Book
                {
                    BookId = 23,
                    Title = "The Iliad",
                    ISBN = "978-0-14-044592-3",
                    Description = "An ancient Greek epic poem set during the Trojan War.",
                    Price = 14.99m,
                    AvailableCopies = 2,
                    TotalCopies = 7,
                    PublicationDate = new DateTime(762, 1, 1).AddYears(-1),
                    Publisher = "Penguin Classics",
                    Language = "English",
                    PageCount = 683,
                    AuthorId = 2,
                    CategoryId = 8
                },
                new Book
                {
                    BookId = 24,
                    Title = "Frankenstein",
                    ISBN = "978-0-14-143947-1",
                    Description = "A novel about a scientist who creates a sapient creature in an unorthodox experiment.",
                    Price = 9.00m,
                    AvailableCopies = 4,
                    TotalCopies = 9,
                    PublicationDate = new DateTime(1818, 1, 1),
                    Publisher = "Penguin Classics",
                    Language = "English",
                    PageCount = 273,
                    AuthorId = 3,
                    CategoryId = 10
                },
                new Book
                {
                    BookId = 25,
                    Title = "The Count of Monte Cristo",
                    ISBN = "978-0-14-044926-6",
                    Description = "An adventure novel about a man wrongfully imprisoned who escapes and seeks revenge.",
                    Price = 16.00m,
                    AvailableCopies = 3,
                    TotalCopies = 8,
                    PublicationDate = new DateTime(1844, 1, 1),
                    Publisher = "Penguin Classics",
                    Language = "English",
                    PageCount = 1276,
                    AuthorId = 4,
                    CategoryId = 8
                },
                new Book
                {
                    BookId = 26,
                    Title = "Les Misérables",
                    ISBN = "978-0-14-044430-8",
                    Description = "A novel set in early 19th-century France, following the lives of several characters.",
                    Price = 16.00m,
                    AvailableCopies = 5,
                    TotalCopies = 10,
                    PublicationDate = new DateTime(1862, 1, 1),
                    Publisher = "Penguin Classics",
                    Language = "English",
                    PageCount = 1232,
                    AuthorId = 5,
                    CategoryId = 9
                },
                new Book
                {
                    BookId = 27,
                    Title = "The Picture of Dorian Gray",
                    ISBN = "978-0-14-043784-3",
                    Description = "A philosophical novel about a man who stays young while his portrait ages.",
                    Price = 9.00m,
                    AvailableCopies = 4,
                    TotalCopies = 9,
                    PublicationDate = new DateTime(1890, 7, 1),
                    Publisher = "Penguin Classics",
                    Language = "English",
                    PageCount = 254,
                    AuthorId = 6,
                    CategoryId = 10
                },
                new Book
                {
                    BookId = 28,
                    Title = "Anna Karenina",
                    ISBN = "978-0-14-044917-4",
                    Description = "A complex novel about an adulterous affair between Anna and Count Vronsky.",
                    Price = 12.99m,
                    AvailableCopies = 2,
                    TotalCopies = 7,
                    PublicationDate = new DateTime(1877, 1, 1),
                    Publisher = "Penguin Classics",
                    Language = "English",
                    PageCount = 964,
                    AuthorId = 7,
                    CategoryId = 1
                },
                new Book
                {
                    BookId = 29,
                    Title = "The Adventures of Huckleberry Finn",
                    ISBN = "978-0-14-243719-3",
                    Description = "A novel about a boy's journey down the Mississippi River with an escaped slave.",
                    Price = 8.00m,
                    AvailableCopies = 3,
                    TotalCopies = 8,
                    PublicationDate = new DateTime(1884, 12, 10),
                    Publisher = "Penguin Classics",
                    Language = "English",
                    PageCount = 366,
                    AuthorId = 8,
                    CategoryId = 8
                },
                new Book
                {
                    BookId = 30,
                    Title = "Alice's Adventures in Wonderland",
                    ISBN = "978-0-14-143976-1",
                    Description = "A novel about a girl who falls through a rabbit hole into a fantasy world.",
                    Price = 7.00m,
                    AvailableCopies = 5,
                    TotalCopies = 10,
                    PublicationDate = new DateTime(1865, 11, 26),
                    Publisher = "Penguin Classics",
                    Language = "English",
                    PageCount = 176,
                    AuthorId = 9,
                    CategoryId = 4
                },
                new Book
                {
                    BookId = 31,
                    Title = "The Scarlet Letter",
                    ISBN = "978-0-14-243818-3",
                    Description = "A novel set in 17th-century Puritan Boston about a woman condemned for adultery.",
                    Price = 8.00m,
                    AvailableCopies = 6,
                    TotalCopies = 12,
                    PublicationDate = new DateTime(1850, 3, 16),
                    Publisher = "Penguin Classics",
                    Language = "English",
                    PageCount = 279,
                    AuthorId = 10,
                    CategoryId = 9
                },
                new Book
                {
                    BookId = 32,
                    Title = "The Old Man and the Sea",
                    ISBN = "978-0-684-80122-3",
                    Description = "A novel about an aging Cuban fisherman's struggle with a giant marlin.",
                    Price = 12.00m,
                    AvailableCopies = 4,
                    TotalCopies = 9,
                    PublicationDate = new DateTime(1952, 9, 1),
                    Publisher = "Scribner",
                    Language = "English",
                    PageCount = 128,
                    AuthorId = 1,
                    CategoryId = 1
                },
                new Book
                {
                    BookId = 33,
                    Title = "The Stranger",
                    ISBN = "978-0-679-72020-1",
                    Description = "A story about an ordinary man who is unwittingly drawn into a murder.",
                    Price = 13.00m,
                    AvailableCopies = 2,
                    TotalCopies = 7,
                    PublicationDate = new DateTime(1942, 1, 1),
                    Publisher = "Vintage International",
                    Language = "English",
                    PageCount = 123,
                    AuthorId = 2,
                    CategoryId = 7
                },
                new Book
                {
                    BookId = 34,
                    Title = "The Trial",
                    ISBN = "978-0-8052-0999-5",
                    Description = "A novel about a man arrested and prosecuted by a remote authority without ever learning the crime.",
                    Price = 15.00m,
                    AvailableCopies = 3,
                    TotalCopies = 8,
                    PublicationDate = new DateTime(1925, 4, 26),
                    Publisher = "Schocken",
                    Language = "English",
                    PageCount = 255,
                    AuthorId = 3,
                    CategoryId = 7
                },
                new Book
                {
                    BookId = 35,
                    Title = "Things Fall Apart",
                    ISBN = "978-0-385-47454-2",
                    Description = "A novel about pre-colonial life in Nigeria and the arrival of Europeans.",
                    Price = 14.00m,
                    AvailableCopies = 4,
                    TotalCopies = 10,
                    PublicationDate = new DateTime(1958, 1, 1),
                    Publisher = "Penguin Books",
                    Language = "English",
                    PageCount = 209,
                    AuthorId = 4,
                    CategoryId = 9
                },
                new Book
                {
                    BookId = 36,
                    Title = "Heart of Darkness",
                    ISBN = "978-0-14-018680-8",
                    Description = "A novella about a voyage up the Congo River into the heart of Africa.",
                    Price = 10.00m,
                    AvailableCopies = 5,
                    TotalCopies = 11,
                    PublicationDate = new DateTime(1899, 2, 1),
                    Publisher = "Penguin Classics",
                    Language = "English",
                    PageCount = 188,
                    AuthorId = 5,
                    CategoryId = 1
                },
                new Book
                {
                    BookId = 37,
                    Title = "Great Expectations",
                    ISBN = "978-0-14-143956-3",
                    Description = "A novel about an orphan named Pip and his journey to becoming a gentleman.",
                    Price = 9.00m,
                    AvailableCopies = 3,
                    TotalCopies = 9,
                    PublicationDate = new DateTime(1861, 8, 1),
                    Publisher = "Penguin Classics",
                    Language = "English",
                    PageCount = 544,
                    AuthorId = 6,
                    CategoryId = 1
                },
                new Book
                {
                    BookId = 38,
                    Title = "Slaughterhouse-Five",
                    ISBN = "978-0-385-33384-9",
                    Description = "An anti-war novel centered on the bombing of Dresden in World War II.",
                    Price = 16.00m,
                    AvailableCopies = 4,
                    TotalCopies = 10,
                    PublicationDate = new DateTime(1969, 3, 31),
                    Publisher = "Dial Press",
                    Language = "English",
                    PageCount = 275,
                    AuthorId = 7,
                    CategoryId = 2
                },
                new Book
                {
                    BookId = 39,
                    Title = "Lolita",
                    ISBN = "978-0-679-72316-5",
                    Description = "A novel about a middle-aged professor's obsession with a twelve-year-old girl.",
                    Price = 16.00m,
                    AvailableCopies = 2,
                    TotalCopies = 7,
                    PublicationDate = new DateTime(1955, 9, 15),
                    Publisher = "Vintage",
                    Language = "English",
                    PageCount = 336,
                    AuthorId = 8,
                    CategoryId = 1
                },
                new Book
                {
                    BookId = 40,
                    Title = "Invisible Man",
                    ISBN = "978-0-679-72318-9",
                    Description = "A novel about the journey of an African American man who feels socially invisible.",
                    Price = 16.00m,
                    AvailableCopies = 3,
                    TotalCopies = 8,
                    PublicationDate = new DateTime(1952, 4, 14),
                    Publisher = "Vintage",
                    Language = "English",
                    PageCount = 581,
                    AuthorId = 9,
                    CategoryId = 1
                },
                new Book
                {
                    BookId = 41,
                    Title = "The Little Prince",
                    ISBN = "978-0-15-601219-5",
                    Description = "A poetic tale about a young prince who visits various planets in space.",
                    Price = 11.00m,
                    AvailableCopies = 6,
                    TotalCopies = 12,
                    PublicationDate = new DateTime(1943, 4, 6),
                    Publisher = "Mariner Books",
                    Language = "English",
                    PageCount = 96,
                    AuthorId = 10,
                    CategoryId = 4
                },
                new Book
                {
                    BookId = 42,
                    Title = "The Call of the Wild",
                    ISBN = "978-0-14-036657-1",
                    Description = "A novel about a dog's journey from domestication to living in the wild.",
                    Price = 5.99m,
                    AvailableCopies = 4,
                    TotalCopies = 10,
                    PublicationDate = new DateTime(1903, 7, 1),
                    Publisher = "Puffin Books",
                    Language = "English",
                    PageCount = 160,
                    AuthorId = 1,
                    CategoryId = 8
                },
                new Book
                {
                    BookId = 43,
                    Title = "Fahrenheit 451",
                    ISBN = "978-1-4516-7331-9",
                    Description = "A novel about a future American society where books are outlawed and firemen burn them.",
                    Price = 15.99m,
                    AvailableCopies = 5,
                    TotalCopies = 11,
                    PublicationDate = new DateTime(1953, 10, 19),
                    Publisher = "Simon & Schuster",
                    Language = "English",
                    PageCount = 249,
                    AuthorId = 2,
                    CategoryId = 2
                },
                new Book
                {
                    BookId = 44,
                    Title = "A Tale of Two Cities",
                    ISBN = "978-0-14-143960-0",
                    Description = "A historical novel set in London and Paris before and during the French Revolution.",
                    Price = 8.00m,
                    AvailableCopies = 3,
                    TotalCopies = 9,
                    PublicationDate = new DateTime(1859, 4, 30),
                    Publisher = "Penguin Classics",
                    Language = "English",
                    PageCount = 489,
                    AuthorId = 3,
                    CategoryId = 9
                },
                new Book
                {
                    BookId = 45,
                    Title = "The Metamorphosis",
                    ISBN = "978-0-486-29030-1",
                    Description = "A novella about a man who wakes up one morning transformed into a huge insect.",
                    Price = 4.00m,
                    AvailableCopies = 6,
                    TotalCopies = 12,
                    PublicationDate = new DateTime(1915, 10, 1),
                    Publisher = "Dover Publications",
                    Language = "English",
                    PageCount = 96,
                    AuthorId = 4,
                    CategoryId = 7
                },
                new Book
                {
                    BookId = 46,
                    Title = "The Wind in the Willows",
                    ISBN = "978-0-14-036664-9",
                    Description = "A novel about the adventures of anthropomorphized animals living by a river.",
                    Price = 6.99m,
                    AvailableCopies = 4,
                    TotalCopies = 10,
                    PublicationDate = new DateTime(1908, 6, 15),
                    Publisher = "Puffin Books",
                    Language = "English",
                    PageCount = 288,
                    AuthorId = 5,
                    CategoryId = 4
                },
                new Book
                {
                    BookId = 47,
                    Title = "Mrs. Dalloway",
                    ISBN = "978-0-15-662870-9",
                    Description = "A novel that details a day in the life of Clarissa Dalloway, an upper-class woman in post-World War I England.",
                    Price = 15.00m,
                    AvailableCopies = 3,
                    TotalCopies = 8,
                    PublicationDate = new DateTime(1925, 5, 14),
                    Publisher = "Harcourt",
                    Language = "English",
                    PageCount = 194,
                    AuthorId = 6,
                    CategoryId = 1
                },
                new Book
                {
                    BookId = 48,
                    Title = "The Sun Also Rises",
                    ISBN = "978-0-7432-9733-2",
                    Description = "A novel about American and British expatriates who travel from Paris to the Festival of San Fermín in Pamplona.",
                    Price = 17.00m,
                    AvailableCopies = 4,
                    TotalCopies = 9,
                    PublicationDate = new DateTime(1926, 10, 22),
                    Publisher = "Scribner",
                    Language = "English",
                    PageCount = 251,
                    AuthorId = 7,
                    CategoryId = 1
                },
                new Book
                {
                    BookId = 49,
                    Title = "David Copperfield",
                    ISBN = "978-0-14-043933-5",
                    Description = "A novel that follows the life of David Copperfield from childhood to maturity.",
                    Price = 10.00m,
                    AvailableCopies = 5,
                    TotalCopies = 10,
                    PublicationDate = new DateTime(1850, 11, 1),
                    Publisher = "Penguin Classics",
                    Language = "English",
                    PageCount = 882,
                    AuthorId = 8,
                    CategoryId = 1
                },
                new Book
                {
                    BookId = 50,
                    Title = "Dracula",
                    ISBN = "978-0-14-143984-6",
                    Description = "A Gothic horror novel about Count Dracula's attempt to move from Transylvania to England.",
                    Price = 9.00m,
                    AvailableCopies = 4,
                    TotalCopies = 9,
                    PublicationDate = new DateTime(1897, 5, 26),
                    Publisher = "Penguin Classics",
                    Language = "English",
                    PageCount = 454,
                    AuthorId = 9,
                    CategoryId = 10
                }
            };

            return initialBooks;
        }

        // Get or create author by name
        private int GetOrCreateAuthor(string authorName)
        {
            if (string.IsNullOrWhiteSpace(authorName))
                return 0;
                
            // Parse author name into first and last name
            string firstName = authorName;
            string lastName = "";
            
            if (authorName.Contains(" "))
            {
                var parts = authorName.Split(' ', 2);
                firstName = parts[0];
                lastName = parts[1];
            }
            
            // Look for existing author
            var author = authors.FirstOrDefault(a => 
                (a.FirstName + " " + a.LastName).Equals(authorName, StringComparison.OrdinalIgnoreCase));
                
            if (author != null)
                return author.AuthorId;
                
            // Create new author
            var newAuthor = new Author
            {
                AuthorId = authors.Any() ? authors.Max(a => a.AuthorId) + 1 : 1,
                FirstName = firstName,
                LastName = lastName,
                BirthDate = null
            };
            
            authors.Add(newAuthor);
            return newAuthor.AuthorId;
        }
        
        // Get or create category by name
        private int GetOrCreateCategory(string categoryName)
        {
            if (string.IsNullOrWhiteSpace(categoryName))
                return 0;
                
            // Look for existing category
            var category = categories.FirstOrDefault(c => 
                c.Name.Equals(categoryName, StringComparison.OrdinalIgnoreCase));
                
            if (category != null)
                return category.CategoryId;
                
            // Create new category
            var newCategory = new Category
            {
                CategoryId = categories.Any() ? categories.Max(c => c.CategoryId) + 1 : 1,
                Name = categoryName,
                Description = $"Books categorized as {categoryName}"
            };
            
            categories.Add(newCategory);
            return newCategory.CategoryId;
        }

        // GET: Book/Catalog - Public view for all users
        public IActionResult Catalog(string searchTerm = null)
        {
            var currentUser = HttpContext.Session.GetObject<User>("CurrentUser");
            ViewBag.IsLibrarian = currentUser?.Role == "Librarian" || currentUser?.Role == "Admin";
            
            IEnumerable<Book> bookList = books;
            
            if (!string.IsNullOrEmpty(searchTerm))
        {
                bookList = bookList.Where(b => 
                    b.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    b.Author.FullName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    b.ISBN.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    b.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    b.Category.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                );
                ViewBag.SearchTerm = searchTerm;
            }
            
            // Make sure we populate the Author and Category navigation properties for each book
            var result = bookList.ToList();
            foreach (var book in result)
            {
                book.Author = authors.FirstOrDefault(a => a.AuthorId == book.AuthorId);
                book.Category = categories.FirstOrDefault(c => c.CategoryId == book.CategoryId);
            }
            
            return View(result);
        }

        // GET: Book/Details/5 - Public view for details
        public IActionResult Details(int id)
        {
            var currentUser = HttpContext.Session.GetObject<User>("CurrentUser");
            ViewBag.IsLibrarian = currentUser?.Role == "Librarian" || currentUser?.Role == "Admin";
            
            var book = books.FirstOrDefault(b => b.BookId == id);
            if (book == null)
            {
                return NotFound();
            }
            
            return View(book);
        }

        // GET: Book - Admin/Librarian view (management)
        [TypeFilter(typeof(LibrarianAuthorizationFilter))]
        public IActionResult Index()
        {
            return View(books);
        }

        // GET: Book/Create - Librarian only
        [TypeFilter(typeof(LibrarianAuthorizationFilter))]
        public IActionResult Create()
        {
            ViewBag.Authors = authors;
            ViewBag.Categories = categories;
            return View();
        }

        // POST: Book/Create - Librarian only
        [HttpPost]
        [ValidateAntiForgeryToken]
        [TypeFilter(typeof(LibrarianAuthorizationFilter))]
        public IActionResult Create(Book book, string authorName, string categoryName)
        {
            if (ModelState.IsValid)
            {
                // Process author and category
                book.AuthorId = GetOrCreateAuthor(authorName);
                book.CategoryId = GetOrCreateCategory(categoryName);
                
                book.BookId = books.Any() ? books.Max(b => b.BookId) + 1 : 1;
                
                // Ensure TotalCopies is set if not provided
                if (book.TotalCopies == 0)
                {
                    book.TotalCopies = book.AvailableCopies;
                }
                
                books.Add(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Book/Edit/5 - Librarian only
        [TypeFilter(typeof(LibrarianAuthorizationFilter))]
        public IActionResult Edit(int id)
        {
            var book = books.FirstOrDefault(b => b.BookId == id);
            if (book == null)
            {
                return NotFound();
            }
            
            // Set the navigation properties for display
            book.Author = authors.FirstOrDefault(a => a.AuthorId == book.AuthorId);
            book.Category = categories.FirstOrDefault(c => c.CategoryId == book.CategoryId);
            
            return View(book);
        }

        // POST: Book/Edit/5 - Librarian only
        [HttpPost]
        [ValidateAntiForgeryToken]
        [TypeFilter(typeof(LibrarianAuthorizationFilter))]
        public IActionResult Edit(int id, Book book, string authorName, string categoryName)
        {
            if (id != book.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingBook = books.FirstOrDefault(b => b.BookId == id);
                if (existingBook != null)
                {
                    // Process author and category
                    existingBook.AuthorId = GetOrCreateAuthor(authorName);
                    existingBook.CategoryId = GetOrCreateCategory(categoryName);
                    
                    existingBook.Title = book.Title;
                    existingBook.ISBN = book.ISBN;
                    existingBook.Description = book.Description;
                    existingBook.AvailableCopies = book.AvailableCopies;
                    existingBook.TotalCopies = book.TotalCopies;
                    existingBook.Price = book.Price;
                    existingBook.PublicationDate = book.PublicationDate;
                    existingBook.Publisher = book.Publisher;
                    existingBook.Language = book.Language;
                    existingBook.PageCount = book.PageCount;
                }
                return RedirectToAction(nameof(Index));
            }
            
            // If we got this far, something failed, reload the form with navigation properties
            book.Author = authors.FirstOrDefault(a => a.AuthorId == book.AuthorId);
            book.Category = categories.FirstOrDefault(c => c.CategoryId == book.CategoryId);
            
            return View(book);
        }

        // GET: Book/Delete/5 - Librarian only
        [TypeFilter(typeof(LibrarianAuthorizationFilter))]
        public IActionResult Delete(int id)
        {
            var book = books.FirstOrDefault(b => b.BookId == id);
            if (book == null)
            {
                return NotFound();
            }
            
            // Set the navigation properties for display
            book.Author = authors.FirstOrDefault(a => a.AuthorId == book.AuthorId);
            book.Category = categories.FirstOrDefault(c => c.CategoryId == book.CategoryId);
            
            return View(book);
        }

        // POST: Book/Delete/5 - Librarian only
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [TypeFilter(typeof(LibrarianAuthorizationFilter))]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = books.FirstOrDefault(b => b.BookId == id);
            if (book != null)
            {
                books.Remove(book);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Book/Search - Public view
        public IActionResult Search(string searchTerm)
        {
            return RedirectToAction("Catalog", new { searchTerm });
        }
    }
} 