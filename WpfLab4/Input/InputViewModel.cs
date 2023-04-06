using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using WpfLab2.Exceptions;
using WpfLab2.Main;

namespace WpfLab2.Input;

public class InputViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private string _name;
    private string _surname;
    private string _email;
	private bool _isReady;
    private bool _allFieldsSet;
    private DateTime? _birthDate;
    
    public InputViewModel()
    {
        _name = string.Empty;
        _surname = string.Empty;
        _email = string.Empty;
        _isReady = true;
        _allFieldsSet = false;
        _birthDate = null;
    }

    public DateTime? BirthDate
    {
        get => _birthDate;
        set
        {
            SetField(ref _birthDate, value);
            CheckAllFields();
        }
    }
    
    public string Name
    {
        get => _name;
        set
        {
            SetField(ref _name, value);
            CheckAllFields();
        }
    }

    public string Surname
    {
        get => _surname;
        set
        {
            SetField(ref _surname, value);
            CheckAllFields();
        }
    }

    public string Email
    {
        get => _email;
        set
        {
            SetField(ref _email, value);
            CheckAllFields();
        }
    }

    public bool AllFieldsSet
    {
        get => _allFieldsSet;
        private set => SetField(ref _allFieldsSet, value);
    }

    public bool IsReady
	{
		get => _isReady;
		set
		{
            SetField(ref _isReady, value);
            IsBusy = true;
		}
	}

    public bool IsBusy
    {
        get => !IsReady;
        private set => OnPropertyChanged();
    }
	
	public async Task<Person> Calculate()
    {
        if (BirthDate is null) throw new InvalidBirthDateException();
		IsReady = false;
		var person = new Person(Name, Surname, Email, BirthDate.Value);
        await Task.Delay(1000);
        IsReady = true;
		return person;
	}

    private void CheckAllFields()
    {
        AllFieldsSet = _name != string.Empty && _surname != string.Empty && _email != string.Empty && _birthDate != null;
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