using ConsoleMenu;
using System.Diagnostics;
using Progress_Bar;

namespace BPlan_Geography_Processor
{
    internal class Program
    {
        public static List<LocationRecord> LocationRecords = new List<LocationRecord>();

        static void Main(string[] args)
        {
            ImportData();

            string[] mainMenuItems = new string[] { "Check Location Definitions", "Build TLK Path", "Download Data File", "Exit"};

            // This list is not really needed, it is purely here for debug purposes to check the contents.
            // List<LocationRecord> records = LocationRecords;

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

            Console.WriteLine("BPlane Geography Data Processor");
            Console.WriteLine("The data is currently being imported");

            while (!sr.EndOfStream)
            {
                Line = sr.ReadLine();

                RecordType = new string(Line[0].ToString() + Line[1].ToString() + Line[2].ToString());

                if (RecordType == "LOC")
                {
                    //Debug.WriteLine("Location record added");
                    RawLocationRecords.Add(Line);
                }
                else if (RecordType == "TLK")
                {
                    //Debug.WriteLine("Timing record added");
                    RawTimingRecords.Add(Line);
                }
                else
                {
                    Debug.WriteLine("Record type {0} skipped.", RecordType);
                }
            }

            sr.Close();

            Debug.WriteLine("Records imported");

            Console.WriteLine("The Location Data is now being processed.");

            foreach (string RawRecord in RawLocationRecords) 
            { 
                LocationRecord Record = new LocationRecord(RawRecord);
                Record.ProcessLocationRecord();

                LocationRecords.Add(Record);
            }

            Console.WriteLine("The timing data is now being processed.");

            Thread.Sleep(1000);
            Console.Clear();
        }
    }

    internal class LocationRecord(string rawRecord)
    {
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public string TimingPointType { get; set; }
        public string StationNumberCode { get; set; }

        private string[] SplitRecords = rawRecord.Split('\t');

        public void ProcessLocationRecord()
        {
            LocationCode = SplitRecords[2];
            LocationName = SplitRecords[3];
            TimingPointType = SplitRecords[8];
            StationNumberCode = SplitRecords[10];
        }
    }
}
