using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using MachineStatusTracker.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace MachineStatusTracker.ViewModels
{
    public partial class MachineStatusTrackerViewModel : ObservableObject
    {
        public ObservableCollection<MachineViewModel> Machines { get; set; } = new ObservableCollection<MachineViewModel>();
        public ListCollectionView FilteredMachines { get; set; }
        public List<string> StatusFilterOptions { get; } = new List<string> { "All" }.Concat(Enum.GetNames(typeof(MachineStatus))).ToList();

        private string _filterStatus;
        public string FilterStatus
        {
            get => _filterStatus;
            set
            {
                _filterStatus = value;
                FilteredMachines.Filter = FilterMachines;
                OnPropertyChanged(nameof(FilterStatus));
            }
        }

        public ICommand AddMachineCommand { get; }
        public ICommand EditMachineCommand { get; }
        public ICommand DeleteMachineCommand { get; }
        public ICommand SelectItemCommand { get; }

        [ObservableProperty] 
        private MachineViewModel _selectedMachine;

        public event PropertyChangedEventHandler PropertyChanged;

        public MachineStatusTrackerViewModel()
        {
            Machines.Add(new MachineViewModel(new Machine { Name = "Machine 1", Description = "Production Line A", Status = MachineStatus.Running, Notes = "Operating normally." }));
            Machines.Add(new MachineViewModel(new Machine { Name = "Machine 2", Description = "Packaging Unit", Status = MachineStatus.Idle, Notes = "Waiting for input." }));
            Machines.Add(new MachineViewModel(new Machine { Name = "Machine 3", Description = "Maintenance Bay", Status = MachineStatus.Offline, Notes = "Under maintenance." }));

            FilteredMachines = new ListCollectionView(Machines);
            FilterStatus = "All";
            FilteredMachines.Filter = FilterMachines;

            AddMachineCommand = new RelayCommand<Window>(AddMachine);
            EditMachineCommand = new RelayCommand<object>(EditMachine);
            DeleteMachineCommand = new RelayCommand<object>(DeleteMachine);
            SelectItemCommand = new RelayCommand<MachineViewModel>(SelectItem);
        }

        private bool FilterMachines(object obj)
        {
            if (string.IsNullOrEmpty(FilterStatus) || FilterStatus == "All") return true;
            return ((MachineViewModel)obj).Status.ToString() == FilterStatus;
        }

        private void AddMachine(Window owner)
        {
            var addVM = new AddEditMachineViewModel(new Machine());
            var addWindow = new Views.AddEditMachineWindow { DataContext = addVM, Owner = owner };

            if (addWindow.ShowDialog() == true)
            {
                Machines.Add(new MachineViewModel(addVM.Machine));
                FilteredMachines.Refresh(); 
                OnPropertyChanged(nameof(Machines));
                MessageBox.Show("Machine added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void EditMachine(object parameter)
        {
            if (parameter is not MachineViewModel SelectedMachine) return;
            var editVM = new AddEditMachineViewModel(SelectedMachine.Machine);
            var editWindow = new Views.AddEditMachineWindow { DataContext = editVM, Owner = Application.Current.MainWindow };

            if (editWindow.ShowDialog() == true)
            {
                FilteredMachines.Refresh();
                MessageBox.Show("Machine updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private bool CanEdit(object parameter)
        {
            return parameter is MachineViewModel;
        }

        private void DeleteMachine(object parameter)
        {
            if (parameter is not MachineViewModel SelectedMachine) return;
            if (MessageBox.Show($"Are you sure you want to delete {SelectedMachine.Name}?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Machines.Remove(SelectedMachine);
                OnPropertyChanged(nameof(Machines));
                MessageBox.Show("Machine deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void SelectItem(object parameter)
        {
            SelectedMachine = (MachineViewModel)parameter;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}