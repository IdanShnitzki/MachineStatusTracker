namespace MachineStatusTracker.Models
{
    public class Machine
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public MachineStatus Status { get; set; }
        public string Notes { get; set; }
    }

    public enum MachineStatus
    {
        Running,
        Idle,
        Offline
    }
}