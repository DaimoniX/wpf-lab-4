using System;
using System.Threading.Tasks;
using System.Windows;
using WpfLab2.Exceptions;
using WpfLab2.Main;

namespace WpfLab2.Input;

public partial class InputWindow : Window
{
    private readonly InputViewModel _inputViewModel;
    public event EventHandler<Person>? OnPersonCreated;

    public InputWindow()
    {
        DataContext = _inputViewModel = new InputViewModel();
        InitializeComponent();
    }

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        if (_inputViewModel.BirthDate is null)
        {
            MessageBox.Show("Input date is empty", "Invalid date", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }


        if (_inputViewModel.BirthDate.Value.IsBirthdayToday())
            MessageBox.Show("Happy birthday!", "Congratulations", MessageBoxButton.OK, MessageBoxImage.Information);
        try
        {
            var person = await Task.Run(() => _inputViewModel.Calculate());
            OnPersonCreated?.Invoke(this, person);
            OnPersonCreated = null;
            Close();
            return;
        }
        catch (EmailFormatException ee)
        {
            MessageBox.Show(ee.Message, "Invalid email", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        catch (InvalidNameSurnameException nse)
        {
            MessageBox.Show(nse.Message, "Invalid name or surname", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        catch (InvalidBirthDateException bd)
        {
            MessageBox.Show(bd.Message, "Invalid date", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show(ex.Message, "Invalid input", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        _inputViewModel.IsReady = true;
    }
}