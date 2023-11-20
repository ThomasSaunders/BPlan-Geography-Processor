using ConsoleMenu;

namespace BPlan_Geography_Processor
{
    internal class Program
    {       
        public static List<LocationRecord> LocationRecords = new List<LocationRecord>();
        public static List<TimingRecord> TimingRecords = new List<TimingRecord>();

        static void Main(string[] args)
        {
            ImportData();

            string[] mainMenuItems = new string[] { "Check Location Definitions", "Build TLK Path", "Download Data File", "Exit"};

            // This list is not really needed, it is purely here for debug purposes to check the contents.
            // List<LocationRecord> records = LocationRecords;
            // List<TimingRecord> records = TimingRecords;

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
                    RawLocationRecords.Add(Line);
                }
                else if (RecordType == "TLK")
                {
                    RawTimingRecords.Add(Line);
                }
            }

            sr.Close();

            Console.WriteLine("The Location Data is now being processed.");

            foreach (string RawRecord in RawLocationRecords) 
            { 
                LocationRecord Record = new LocationRecord(RawRecord);
                Record.ProcessLocationRecord();

                LocationRecords.Add(Record);
            }

            Console.WriteLine("The timing data is now being processed.");

            foreach (string RawRecord in RawTimingRecords)
            {
                TimingRecord Record = new TimingRecord(RawRecord);
                Record.ProcessTimingRecord();

                if (Record.RunningCodeLine.ToUpper() != "BUS")
                {
                    TimingRecords.Add(Record);
                }
            }

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

    internal class TimingRecord(string rawRecord)
    {
        public string OriginLocation { get; set; }
        public string DestinationLocation { get; set; }
        public string RunningCodeLine { get; set; }
        public string TractionType { get; set; }
        public string TrailingLoad { get; set; }
        public string EntrySpeed { get; set; }
        public string ExitSpeed { get; set; }
        public string SectionalRunningTime { get; set; }
        private string[] SplitRecords = rawRecord.Split('\t');

        public void ProcessTimingRecord()
        {
            OriginLocation = SplitRecords[2];
            DestinationLocation = SplitRecords[3];
            RunningCodeLine = SplitRecords[4];
            TractionType = SplitRecords[5];
            TrailingLoad = SplitRecords[6];
            EntrySpeed = SplitRecords[9];
            ExitSpeed = SplitRecords[10];
            SectionalRunningTime = SplitRecords[13];
        }
    }
}
