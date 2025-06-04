using System.Collections.Generic;

namespace SharedLibrary
{
    /// <summary>
    /// Interface defining the contract for contact serialization plugins
    /// </summary>
    public interface IPluginable
    {
        /// <summary>
        /// Saves a list of contacts to a file
        /// </summary>
        /// <param name="contacts">The list of contacts to save</param>
        /// <param name="filePath">The path where to save the file</param>
        void Save(List<Contact> contacts, string filePath);

        /// <summary>
        /// Loads a list of contacts from a file
        /// </summary>
        /// <param name="filePath">The path of the file to load</param>
        /// <returns>A list of contacts loaded from the file</returns>
        List<Contact> Load(string filePath);

        /// <summary>
        /// Gets the format name for this serialization method
        /// </summary>
        string Format { get; }
    }
} 