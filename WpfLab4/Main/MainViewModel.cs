using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfLab2.Main;

public class MainViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    
    private Person? _person;
    private bool _isSet;
    private bool _inputWindowHidden;

    public MainViewModel()
    {
        _person = null;
        _isSet = false;
        _inputWindowHidden = true;
    }

    public bool IsSet
    {
        get => _isSet;
        private set => SetField(ref _isSet, value);
    }
    
    public Person? Person
    {
        get => _person;
        set
        {
            IsSet = true;
            SetField(ref _person, value);
            OnPropertyChanged(null);
        }
    }

    public bool InputWindowHidden
    {
        get => _inputWindowHidden;
        set => SetField(ref _inputWindowHidden, value);
    }
    
    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}