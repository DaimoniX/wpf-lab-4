using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace WpfLab2.Main;

public class SerializationManager
{
    private readonly string _path;
    
    public SerializationManager(string path)
    {
        _path = path;
    }

    public void SerializeUsers(ObservableCollection<Person> users)
    {
        var serializedData = JsonSerializer.Serialize(users, new JsonSerializerOptions{ WriteIndented = true });
        File.WriteAllText(_path, serializedData);
    }

    public ObservableCollection<Person>? DeserializeUsers()
    {
        return JsonSerializer.Deserialize<ObservableCollection<Person>>(File.ReadAllText(_path));
    }

    public bool HasDatabase()
    {
        return File.Exists(_path);
    }
}