using MachineStatusTracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MachineStatusTracker.ViewModels
{
    public class AddEditMachineViewModel : INotifyPropertyChanged
    {
        public Machine Machine { get; }
        public List<MachineStatus> StatusOptions { get; } = new List<MachineStatus>((MachineStatus[])Enum.GetValues(typeof(MachineStatus)));
        public event PropertyChangedEventHandler PropertyChanged;

        public AddEditMachineViewModel(Machine machine)
        {
            Machine = machine;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}