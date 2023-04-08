using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace WpfLab2.Main;

public class MainViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    
    private bool _inputWindowHidden;
    private bool _dbHasSelection;

    private ObservableCollection<Person> _usersDb;
    private readonly SerializationManager _serialization;
    private static readonly string DbPath = Path.Combine(Directory.GetCurrentDirectory(), "usersDb.json");

    public MainViewModel()
    {
        _inputWindowHidden = true;
        _serialization = new SerializationManager(DbPath);
        try
        {
            if (_serialization.HasDatabase())
                _usersDb = _serialization.DeserializeUsers() ?? throw new NullReferenceException();
            if (_usersDb is null)
                throw new NullReferenceException();
        }
        catch (Exception)
        {
            var generator = new PersonGenerator();
            _usersDb = new ObservableCollection<Person>();
            for (var i = 0; i < 1000; i++)
                UsersDb.Add(generator.GeneratePerson());
        }
        Save();
    }

    public bool InputWindowHidden
    {
        get => _inputWindowHidden;
        set => SetField(ref _inputWindowHidden, value);
    }
    
    public bool DbHasSelection
    {
        get => _dbHasSelection;
        set => SetField(ref _dbHasSelection, value);
    }
    
    public ObservableCollection<Person> UsersDb
    {
        get => _usersDb;
        set => SetField(ref _usersDb, value);
    }
    
    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return;
        field = value;
        OnPropertyChanged(propertyName);
    }

    public void Save()
    {
        _serialization.SerializeUsers(_usersDb);
    }
}