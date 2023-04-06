using System;
using System.Windows;
using WpfLab2.Input;

namespace WpfLab2.Main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _mainViewModel;
        
        public MainWindow()
        {
            DataContext = _mainViewModel = new MainViewModel();
            InitializeComponent();
        }

        private void ShowInputButton_OnClick(object sender, RoutedEventArgs e)
        {
            var inputWindow = new InputWindow();
            inputWindow.OnPersonCreated += DisplayPerson;
            inputWindow.Closed += InputWindowOnClosed;
            _mainViewModel.InputWindowHidden = false;
            inputWindow.Show();
        }

        private void InputWindowOnClosed(object? sender, EventArgs e)
        {
            _mainViewModel.InputWindowHidden = true;
        }

        private void DisplayPerson(object? sender, Person person)
        {
            _mainViewModel.Person = person;
        }
    }
}