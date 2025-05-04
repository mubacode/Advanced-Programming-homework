// Volume.cs
public class Volume : Book
{
    public int VolumeNumber { get; set; }
    public int TotalVolumes { get; set; }

    public Volume() : base()
    {
    }

    public Volume(string isbn, string title, int publicationYear, int pageCount,
                 string author, int volumeNumber, int totalVolumes)
        : base(isbn, title, publicationYear, pageCount, author)
    {
        VolumeNumber = volumeNumber;
        TotalVolumes = totalVolumes;
    }

    public override string Print()
    {
        return $"Printing Volume {VolumeNumber}/{TotalVolumes}: {Title}";
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Volume: {VolumeNumber}/{TotalVolumes}";
    }
}