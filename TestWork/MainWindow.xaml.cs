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
        private const string FileName = "Passengers.json";
        private ObservableCollection<Passenger> passengers = new ObservableCollection<Passenger>();

        public MainWindow()
        {
            InitializeComponent();

            if (File.Exists(FileName))
            {
                var json = File.ReadAllText(FileName);
                passengers = JsonSerializer.Deserialize<ObservableCollection<Passenger>>(json);
            }
            dataGrid.ItemsSource = passengers;
        }

        private void MyDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                var bindingGroup = e.Row.BindingGroup;
                if (bindingGroup != null && bindingGroup.CommitEdit())
                {
                    var json = JsonSerializer.Serialize(passengers);
                    File.WriteAllText(FileName, json);
                }
            }
        }
    }
}
