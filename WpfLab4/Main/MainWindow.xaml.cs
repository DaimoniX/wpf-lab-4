using System;
using System.Windows;
using System.Windows.Controls;
using WpfLab2.Input;

namespace WpfLab2.Main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly MainViewModel _mainViewModel;

        public MainWindow()
        {
            DataContext = _mainViewModel = new MainViewModel();
            InitializeComponent();
            UsersGrid.DataContext = _mainViewModel.UsersDb;
        }

        private void AddToDb(Person person)
        {
            _mainViewModel.UsersDb.Add(person);
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            if (UsersGrid.SelectedItem is not Person person) return;
            var inputWindow = new InputWindow(person);
            inputWindow.OnPersonCreated += InputWindowOnOnPersonEdited;
            inputWindow.Closed += InputWindowOnClosed;
            _mainViewModel.InputWindowHidden = false;
            inputWindow.Show();
        }

        private void RemoveButtonClick(object sender, RoutedEventArgs e)
        {
            if (UsersGrid.SelectedIndex > -1)
                _mainViewModel.UsersDb.RemoveAt(SelectedIndex());
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

        private void InputWindowOnOnPersonEdited(object? sender, Person p)
        {
            _mainViewModel.UsersDb[SelectedIndex()] = p;
        }

        private void InputWindowOnOnPersonCreated(object? sender, Person e)
        {
            AddToDb(e);
        }

        private void UsersGridOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _mainViewModel.DbHasSelection = UsersGrid.SelectedIndex > -1;
        }

        private int SelectedIndex()
        {
            var selectedItem = UsersGrid.SelectedItem;
            if (selectedItem is not Person selectedPerson) return -1;
            return _mainViewModel.UsersDb.IndexOf(selectedPerson);
        }
    }
}