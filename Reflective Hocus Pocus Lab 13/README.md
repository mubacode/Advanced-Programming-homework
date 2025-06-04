# Contact Manager with Plugin Support

This Windows Forms application demonstrates the implementation of an extensible contact management system with plugin support. The application showcases various advanced C# concepts and design patterns.

## 1. Core Concepts from Previous Labs

### Polymorphism
The application uses polymorphism through the `IPluginable` interface, allowing different serialization implementations to be treated uniformly:

```csharp
public interface IPluginable
{
    string Format { get; }
    void Save(List<Contact> contacts, string path);
    List<Contact> Load(string path);
}

// Different implementations can be used polymorphically
IPluginable jsonPlugin = new JsonContactSerializer();
IPluginable xmlPlugin = new XmlContactSerializer();
```

### Interfaces
The application uses interfaces for loose coupling and plugin support:
```csharp
public interface IPluginable
{
    string Format { get; }
    void Save(List<Contact> contacts, string path);
    List<Contact> Load(string path);
}
```

### Generics
Generics are used in several places, including the contact list and serialization:
```csharp
private List<Contact> _contacts;
public List<Contact> Load(string path)
{
    return JsonSerializer.Deserialize<List<Contact>>(jsonString, options);
}
```

### Delegates and Events
The application uses delegates for event handling in the Windows Forms UI:
```csharp
dataGridView1.DataError += DataGridView1_DataError;
saveItem.Click += (s, e) => SaveContacts(plugin);
```

### LINQ
LINQ is used for plugin discovery and type filtering:
```csharp
var types = assembly.GetTypes()
    .Where(t => t.IsClass && t.GetInterface(nameof(IPluginable)) != null);
```

## 2. Designing an Extensible Application

1. **Start with Abstraction**
   - Define common interfaces and base types
   - Identify extension points
   - Create a shared library for common code

2. **Separation of Concerns**
   - Core functionality in the main application
   - Extension points through interfaces
   - Plugin system for additional features

3. **Project Structure**
   ```
   Solution/
   ├── SharedLibrary/      # Common interfaces and models
   ├── ContactManager/     # Main Windows Forms application
   └── Plugins/           # Plugin implementations
       └── JsonPlugin/    # JSON serialization plugin
   ```

## 3. Extensible Application as Shared Code Base

The application demonstrates shared code base through:

1. **Common Types in SharedLibrary**
   - Contact model
   - IPluginable interface
   - InfoAttribute

2. **Plugin System**
   - Plugins can be developed independently
   - No recompilation of main application needed
   - Common interface ensures compatibility

## 4. Plugin Socket Implementation

The plugin system is implemented using reflection:

```csharp
private void LoadPlugins()
{
    DirectoryInfo directoryInfo = new DirectoryInfo(_pluginsPath);
    foreach (FileInfo file in directoryInfo.GetFiles())
    {
        // Load assembly dynamically
        Assembly assembly = Assembly.LoadFrom(file.FullName);
        
        // Find plugin types
        var types = assembly.GetTypes()
            .Where(t => t.IsClass && t.GetInterface(nameof(IPluginable)) != null);

        foreach (Type type in types)
        {
            // Create plugin instance
            object? obj = Activator.CreateInstance(type);
            if (obj != null)
            {
                IPluginable plugin = (IPluginable)obj;
                _plugins.Add(plugin);
                // Add menu items for the plugin...
            }
        }
    }
}
```

## 5. Implementing a Plugin

To create a plugin:

1. Create a new class library project
2. Reference SharedLibrary
3. Implement IPluginable interface
4. Add InfoAttribute

Example:
```csharp
[Info(Author = "MP")]
public class JsonContactSerializer : IPluginable
{
    public string Format => "JSON";

    public void Save(List<Contact> contacts, string path)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(contacts, options);
        File.WriteAllText(path, jsonString);
    }

    public List<Contact> Load(string path)
    {
        string jsonString = File.ReadAllText(path);
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        return JsonSerializer.Deserialize<List<Contact>>(jsonString, options) ?? new List<Contact>();
    }
}
```

## 6. Reflection

Reflection is a mechanism that allows code to inspect and manipulate program elements at runtime:
- Loading assemblies dynamically
- Discovering types and their members
- Creating instances of types
- Reading attributes

Example in our application:
```csharp
// Load assembly
Assembly assembly = Assembly.LoadFrom(file.FullName);

// Find types implementing IPluginable
var types = assembly.GetTypes()
    .Where(t => t.IsClass && t.GetInterface(nameof(IPluginable)) != null);

// Create instance
object? obj = Activator.CreateInstance(type);

// Read attribute
var attrObj = type.GetCustomAttribute(typeof(InfoAttribute));
```

## 7. Attributes

Attributes are metadata that can be attached to program elements:
- Provide additional information about types, methods, properties
- Can be read at runtime using reflection
- Used for declarative programming

Example:
```csharp
[AttributeUsage(AttributeTargets.Class)]
public class InfoAttribute : Attribute
{
    public string Author { get; set; }
}

[Info(Author = "MP")]
public class JsonContactSerializer : IPluginable
{
    // Implementation...
}
```

## 8. Serialization

Serialization is the process of converting objects into a format that can be stored or transmitted:
- Converting objects to XML, JSON, or other formats
- Storing and retrieving data
- Data interchange between systems

Example:
```csharp
// JSON Serialization
string jsonString = JsonSerializer.Serialize(contacts, options);
var contacts = JsonSerializer.Deserialize<List<Contact>>(jsonString, options);

// XML Serialization
var serializer = new XmlSerializer(typeof(List<Contact>));
serializer.Serialize(stream, contacts);
var contacts = (List<Contact>)serializer.Deserialize(stream);
```

## Running the Application

1. Build the solution
2. Copy plugin DLLs to the Plugins directory
3. Run the ContactManager application
4. Use File menu to save/load contacts in different formats
5. Check Help menu for plugin information

## Setup Instructions

### Setting up the DataGridView
1. Drag the DataGridView control from the ToolBox to the form
2. Click the small black triangle in the upper right corner
3. Click on "Choose Data Source" dropdown
4. Click "Add new Object Data Source" at the bottom
5. Select the checkbox next to the shared library name
6. Click OK
7. Expand "Other Data Sources" and select the Contact class

### Building and Running
1. Build the solution
2. Copy plugin DLLs to the Plugins folder in the output directory
3. Run the application

### Creating New Plugins
1. Create a new Class Library project
2. Add reference to SharedLibrary
3. Implement IPluginable interface
4. Add InfoAttribute with author information
5. Build and copy DLL to Plugins folder 