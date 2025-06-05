using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using SharedLibrary;

namespace JsonPlugin
{
    /// <summary>
    /// Plugin for serializing contacts to JSON format
    /// </summary>
    [Info("MP")]
    public class JsonContactSerializer : IPluginable
    {
        /// <summary>
        /// Gets the format name for this serialization method
        /// </summary>
        public string Format => "JSON";

        /// <summary>
        /// Saves a list of contacts to a JSON file
        /// </summary>
        /// <param name="contacts">The list of contacts to save</param>
        /// <param name="path">The path where to save the file</param>
        public void Save(List<Contact> contacts, string path)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(contacts, options);
            File.WriteAllText(path, jsonString);
        }

        /// <summary>
        /// Loads a list of contacts from a JSON file
        /// </summary>
        /// <param name="path">The path of the file to load</param>
        /// <returns>A list of contacts loaded from the file</returns>
        public List<Contact> Load(string path)
        {
            string jsonString = File.ReadAllText(path);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<List<Contact>>(jsonString, options) ?? new List<Contact>();
        }
    }
} 