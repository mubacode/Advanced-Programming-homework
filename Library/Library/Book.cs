// Book.cs
public class Book : Document
{
    public string Author { get; set; }

    public Book() : base()
    {
    }

    public Book(string isbn, string title, int publicationYear, int pageCount, string author)
        : base(isbn, title, publicationYear, pageCount)
    {
        Author = author;
    }

    public override string Print()
    {
        return $"Printing Book: {Title} by {Author}";
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Author: {Author}";
    }
}