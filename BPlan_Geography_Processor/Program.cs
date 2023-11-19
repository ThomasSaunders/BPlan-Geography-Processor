using ConsoleMenu;

namespace BPlan_Geography_Processor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] mainMenuItems = new string[] { "Check Location Definitions", "Build TLK Path", "Exit"};

            Menu mainMenu = new Menu(mainMenuItems, "BPlan Geography Data Processor");

            switch (mainMenu.displayMenu())
            {
                case 1:
                    break;
                case 2:
                    break; 
                case 3:
                    Environment.Exit(0);
                    break;
                default: 
                    break;
            }
        }
    internal class LocationRecords(string rawRecord)
    {
        private string RawRecord = rawRecord;
        public string LocationCode { get; }
        public string LocationName { get; }
        public string TimingPointType {  get; }
        public int StationNumberCode {  get; }

    }
}
