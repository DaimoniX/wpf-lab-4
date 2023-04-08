using System;
using System.Collections.ObjectModel;
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
        private readonly ObservableCollection<Person> _users;

        public MainWindow()
        {
            var generator = new PersonGenerator();
            DataContext = _mainViewModel = new MainViewModel();
            _users = new ObservableCollection<Person>();
            InitializeComponent();
            for(var i = 0; i < 1000; i++)
                AddToDb(generator.GeneratePerson());
            UsersGrid.DataContext = _users;
        }

        public void AddToDb(Person person)
        {
            _users.Add(person);
        }

        private void RemoveButtonClick(object sender, RoutedEventArgs e)
        {
            if(UsersGrid.SelectedIndex > -1)
                _users.RemoveAt(UsersGrid.SelectedIndex);
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            var inputWindow = new InputWindow();
            inputWindow.OnPersonCreated += InputWindowOnOnPersonCreated;
            inputWindow.Closed += InputWindowOnClosed;
            _mainViewModel.InputWindowHidden = false;
            inputWindow.Show();
        }

        private void InputWindowOnClosed(object? sender, EventArgs e)
        {
            _mainViewModel.InputWindowHidden = true;
        }

        private void InputWindowOnOnPersonCreated(object? sender, Person e)
        {
            AddToDb(e);
        }
    }
}