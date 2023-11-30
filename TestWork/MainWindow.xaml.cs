using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using TestWork.Models;

namespace TestWork
{
    public partial class MainWindow : Window
    {
        private const string _fileName = "Passengers.json";
        private ObservableCollection<Passenger> _passengers = new ObservableCollection<Passenger>();

        public MainWindow()
        {
            InitializeComponent();

            if (File.Exists(_fileName))
            {
                var json = File.ReadAllText(_fileName);
                _passengers = JsonSerializer.Deserialize<ObservableCollection<Passenger>>(json);
            }
            dataGrid.ItemsSource = _passengers;
        }

        private void MyDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                var bindingGroup = e.Row.BindingGroup;
                if (bindingGroup != null && bindingGroup.CommitEdit())
                {
                    var json = JsonSerializer.Serialize(_passengers);
                    File.WriteAllText(_fileName, json);
                }
            }
        }
    }
}
