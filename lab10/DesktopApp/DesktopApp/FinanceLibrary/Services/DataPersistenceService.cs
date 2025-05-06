using FinanceLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace FinanceLibrary.Services
{
    public class DataPersistenceService
    {
        private readonly string _dataDirectory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "PersonalFinanceTracker"
        );

        public DataPersistenceService()
        {
            if (!Directory.Exists(_dataDirectory))
            {
                Directory.CreateDirectory(_dataDirectory);
            }
        }

        public async Task SaveDataAsync<T>(string fileName, IEnumerable<T> data) where T : IFinancialEntity
        {
            var filePath = Path.Combine(_dataDirectory, fileName);
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            await File.WriteAllTextAsync(filePath, json);
        }

        public async Task<IEnumerable<T>> LoadDataAsync<T>(string fileName) where T : IFinancialEntity
        {
            var filePath = Path.Combine(_dataDirectory, fileName);
            if (!File.Exists(filePath))
            {
                return new List<T>();
            }

            var json = await File.ReadAllTextAsync(filePath);
            return JsonSerializer.Deserialize<IEnumerable<T>>(json) ?? new List<T>();
        }
    }
} 