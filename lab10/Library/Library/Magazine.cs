// Magazine.cs
public class Magazine : Document
{
    public int Number { get; set; }
    public Frequency PublicationFrequency { get; set; }

    public Magazine() : base()
    {
    }

    public Magazine(string isbn, string title, int publicationYear, int pageCount,
                   int number, Frequency frequency)
        : base(isbn, title, publicationYear, pageCount)
    {
        Number = number;
        PublicationFrequency = frequency;
    }

    public override string Print()
    {
        return $"Printing Magazine: {Title} #{Number}";
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Number: {Number}, Frequency: {PublicationFrequency}";
    }
}