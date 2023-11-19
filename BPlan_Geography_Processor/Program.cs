using ConsoleMenu;
using System.Diagnostics;

namespace BPlan_Geography_Processor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ImportData();

            string[] mainMenuItems = new string[] { "Check Location Definitions", "Build TLK Path", "Download Data File", "Exit"};

            Menu mainMenu = new Menu(mainMenuItems, "BPlan Geography Data Processor");

            switch (mainMenu.displayMenu())
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default: 
                    break;
            }
        }

        static void ImportData()
        {
            string Line, RecordType;
            List<string> RawLocationRecords = new List<string>();
            List<string> RawTimingRecords = new List<string>();

            StreamReader sr = new StreamReader("data.txt");

            while (sr.EndOfStream) 
            { 
                Line = sr.ReadLine();

                RecordType = new string(Line[0].ToString() + Line[1].ToString() + Line[2].ToString());

                if (RecordType == "LOC")
                {
                    Debug.WriteLine("Location record added");
                    RawLocationRecords.Add(Line);
                } else if (RecordType == "TLK")
                {
                    Debug.WriteLine("Timing record added");
                    RawTimingRecords.Add(Line);
                } else
                {
                    Debug.WriteLine("Record type {0} skipped.", RecordType);
                }
            }
        }
    }

    internal class LocationRecord(string rawRecords)
    {
        private string RawRecords = rawRecords;
        public string LocationCode { get; }
        public string LocationName { get; }
        public string TimingPointType {  get; }
        public int StationNumberCode {  get; }

    }
}
