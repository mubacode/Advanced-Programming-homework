// Exceptions/DocumentExceptions.cs
public class DuplicateISBNException : Exception
{
    public DuplicateISBNException() : base("A document with this ISBN already exists.")
    {
    }
}

public class InvalidVolumeNumberException : Exception
{
    public InvalidVolumeNumberException() : base("Volume number cannot be greater than total volumes.")
    {
    }
}

public class InvalidPublicationYearException : Exception
{
    public InvalidPublicationYearException() : base("Publication year cannot be earlier than 1440 (invention of printing).")
    {
    }
}