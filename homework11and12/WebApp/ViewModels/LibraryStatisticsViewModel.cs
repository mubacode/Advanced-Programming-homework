using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.ViewModels
{
    public class LibraryStatisticsViewModel
    {
        public int TotalBooks { get; set; }
        public int TotalAuthors { get; set; }
        public int TotalCategories { get; set; }
        public int AvailableBooks { get; set; }
        public int TotalBookCopies { get; set; }
        public List<CategoryStatistics> BooksPerCategory { get; set; }
        public List<AuthorStatistics> BooksPerAuthor { get; set; }
        public List<Book> RecentlyAddedBooks { get; set; }
        public List<LanguageStatistics> MostPopularLanguages { get; set; }
    }

    public class CategoryStatistics
    {
        public string CategoryName { get; set; }
        public int BookCount { get; set; }
    }

    public class AuthorStatistics
    {
        public string AuthorName { get; set; }
        public int BookCount { get; set; }
    }

    public class LanguageStatistics
    {
        public string Language { get; set; }
        public int BookCount { get; set; }
    }
} 