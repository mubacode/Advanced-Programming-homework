using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using SharedLibrary;

namespace ContactManager
{
    public class PluginLoader
    {
        private readonly string _pluginsPath;

        public PluginLoader(string pluginsPath)
        {
            _pluginsPath = pluginsPath;
            if (!Directory.Exists(_pluginsPath))
            {
                Directory.CreateDirectory(_pluginsPath);
            }
        }

        public IEnumerable<IPluginable> LoadPlugins()
        {
            var plugins = new List<IPluginable>();
            
            // Get all DLL files from the plugins directory
            var dllFiles = Directory.GetFiles(_pluginsPath, "*.dll");
            
            foreach (var dll in dllFiles)
            {
                try
                {
                    // Load the assembly
                    var assembly = Assembly.LoadFrom(dll);
                    
                    // Find types that implement IPluginable
                    var pluginTypes = assembly.GetTypes()
                        .Where(t => typeof(IPluginable).IsAssignableFrom(t) && !t.IsInterface);
                    
                    foreach (var type in pluginTypes)
                    {
                        if (Activator.CreateInstance(type) is IPluginable plugin)
                        {
                            plugins.Add(plugin);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log or handle the error appropriately
                    System.Diagnostics.Debug.WriteLine($"Error loading plugin {dll}: {ex.Message}");
                }
            }
            
            return plugins;
        }
    }
} 