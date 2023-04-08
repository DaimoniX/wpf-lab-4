using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
            UsersGrid.DataContext = _mainViewModel.UsersDb;
        }

        public void AddToDb(Person person)
        {
            _mainViewModel.UsersDb.Add(person);
        }

        private void RemoveButtonClick(object sender, RoutedEventArgs e)
        {
            if (UsersGrid.SelectedIndex > -1)
                _mainViewModel.UsersDb.RemoveAt(UsersGrid.SelectedIndex);
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

        private void UsersGridOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _mainViewModel.DbHasSelection = UsersGrid.SelectedIndex > -1;
        }
    }
}