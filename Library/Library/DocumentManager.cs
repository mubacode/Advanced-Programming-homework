// DocumentManager.cs
public class DocumentManager
{
    private List<Document> documents;
    private const int PRINTING_INVENTION_YEAR = 1440;

    public DocumentManager()
    {
        documents = new List<Document>();
    }

    public void AddDocument(Document document)
    {
        // Check for duplicate ISBN
        if (documents.Any(d => d.ISBN == document.ISBN))
        {
            throw new DuplicateISBNException();
        }

        // Check publication year
        if (document.PublicationYear < PRINTING_INVENTION_YEAR)
        {
            throw new InvalidPublicationYearException();
        }

        // Check volume number if it's a Volume
        if (document is Volume volume)
        {
            if (volume.VolumeNumber > volume.TotalVolumes)
            {
                throw new InvalidVolumeNumberException();
            }
        }

        documents.Add(document);
    }

    public Document GetByISBN(string isbn)
    {
        return documents.FirstOrDefault(d => d.ISBN == isbn);
    }

    public List<Document> SearchByTitle(string phrase)
    {
        return documents.Where(d => d.Title.Contains(phrase)).ToList();
    }

    public List<Magazine> GetMagazinesByFrequency(Frequency frequency)
    {
        return documents.OfType<Magazine>()
                       .Where(m => m.PublicationFrequency == frequency)
                       .ToList();
    }

    public List<Document> GetAllDocuments()
    {
        return documents.ToList();
    }
}