using MachineStatusTracker.Models;
using System.ComponentModel;

namespace MachineStatusTracker.ViewModels
{
    public class MachineViewModel : INotifyPropertyChanged
    {
        public Machine Machine { get; }

        public string Name
        {
            get => Machine.Name;
            set { Machine.Name = value; OnPropertyChanged(nameof(Name)); }
        }
        public string Description
        {
            get => Machine.Description;
            set { Machine.Description = value; OnPropertyChanged(nameof(Description)); }
        }
        public MachineStatus Status
        {
            get => Machine.Status;
            set { Machine.Status = value; OnPropertyChanged(nameof(Status)); }
        }
        public string Notes
        {
            get => Machine.Notes;
            set { Machine.Notes = value; OnPropertyChanged(nameof(Notes)); }
        }

        public MachineViewModel(Machine machine)
        {
            Machine = machine;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}