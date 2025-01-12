using MachineStatusTracker.Models;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using static MachineStatusTracker.Models.Machine;

namespace MachineStatusTracker.Converters
{
    public class StatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is MachineStatus status)
            {
                switch (status)
                {
                    case MachineStatus.Running:
                        return Brushes.Green;
                    case MachineStatus.Idle:
                        return Brushes.Orange;
                    case MachineStatus.Offline:
                        return Brushes.Red;
                    default:
                        return Brushes.Black;
                }
            }
            return Brushes.Black; 
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
