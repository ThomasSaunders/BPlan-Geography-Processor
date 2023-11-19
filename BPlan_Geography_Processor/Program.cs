using ConsoleMenu;
using System.Diagnostics;
using Progress_Bar;

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

            // StreamReader sr = new StreamReader("data.txt");

            string[] RawData = File.ReadAllLines("data.txt");

            ProgressBar progressBar = new ProgressBar("Reading Data", RawData.Length);

            for (int i = 0; i < RawData.Length; i++) 
            {
                progressBar.printProgressBar(i);

                Line = RawData[i];

                RecordType = new string(Line[0].ToString() + Line[1].ToString() + Line[2].ToString());

                if (RecordType == "LOC")
                {
                    Debug.WriteLine("Location record added");
                    RawLocationRecords.Add(Line);
                }
                else if (RecordType == "TLK")
                {
                    Debug.WriteLine("Timing record added");
                    RawTimingRecords.Add(Line);
                }
                else
                {
                    Debug.WriteLine("Record type {0} skipped.", RecordType);
                }

                Thread.Sleep(10);
            }

/*            while (!sr.EndOfStream) 
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

            sr.Close();*/

            Debug.WriteLine("Records imported");

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
