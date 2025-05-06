// Program.cs
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Document Management System");
        var manager = new DocumentManager();

        try
        {
            // Adding books
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nAdding books...");
            manager.AddDocument(new Book("ISBN1", "The Great Gatsby", 1925, 180, "F. Scott Fitzgerald"));
            manager.AddDocument(new Book("ISBN2", "1984", 1949, 328, "George Orwell"));

            // Adding volumes
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nAdding volumes...");
            manager.AddDocument(new Volume("ISBN3", "Lord of the Rings", 1954, 423, "J.R.R. Tolkien", 1, 3));
            manager.AddDocument(new Volume("ISBN4", "Lord of the Rings", 1954, 352, "J.R.R. Tolkien", 2, 3));

            // Adding magazines
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nAdding magazines...");
            manager.AddDocument(new Magazine("MAG1", "Science Today", 2023, 45, 1, Frequency.Monthly));
            manager.AddDocument(new Magazine("MAG2", "Daily News", 2023, 20, 1, Frequency.Daily));

            // Display all documents
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nAll documents:");
            foreach (var doc in manager.GetAllDocuments())
            {
                Console.WriteLine(doc);
            }

            // Search by title
            Console.WriteLine("\nSearching for 'Lord':");
            var searchResults = manager.SearchByTitle("Lord");
            foreach (var doc in searchResults)
            {
                Console.WriteLine(doc);
            }

            // Get magazines by frequency
            Console.WriteLine("\nMonthly magazines:");
            var monthlyMagazines = manager.GetMagazinesByFrequency(Frequency.Monthly);
            foreach (var magazine in monthlyMagazines)
            {
                Console.WriteLine(magazine);
            }

            // Print all documents
            Console.WriteLine("\nPrinting all documents:");
            foreach (var doc in manager.GetAllDocuments())
            {
                Console.WriteLine(doc.Print());
            }

            // Test exceptions
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nTesting exceptions:");

            // Duplicate ISBN
            manager.AddDocument(new Book("ISBN1", "Duplicate Test", 2023, 100, "Test Author"));
        }
        catch (DuplicateISBNException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (InvalidVolumeNumberException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (InvalidPublicationYearException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }

        Console.ResetColor();
    }
}