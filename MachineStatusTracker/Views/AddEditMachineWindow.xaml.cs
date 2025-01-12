using MachineStatusTracker.ViewModels;
using System.Windows;

namespace MachineStatusTracker.Views
{
    public partial class AddEditMachineWindow : Window
    {
        public AddEditMachineWindow()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var vm = (AddEditMachineViewModel)DataContext;
            if (string.IsNullOrWhiteSpace(vm.Machine.Name))
            {
                MessageBox.Show("Machine name is required.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}