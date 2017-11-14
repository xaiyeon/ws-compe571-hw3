using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.ComponentModel;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;
using ws_scheduling_hw3_571.Resources;

namespace ws_scheduling_hw3_571
{
    /**
     * By Royce Aquino and JP
     * 
     * 
     * So what we need to do for Rate Monotonic is get the LCM of each period of the tasks.
     * 
     * 
     * 
     */


    class Program
    {


        static void Main(string[] args)
        {
            // Creating object from our classes.
            RateMonotonic wsRM = new RateMonotonic();
            InputData wsID = new InputData();

            // Other variables
            string textFile;

            // This is our function to read the data and store into a string
            textFile = wsID.getData();
            Console.WriteLine(textFile);

            Console.WriteLine("Starting with Rate Monotonic.");


            var searcher = new ManagementObjectSearcher("Select * from Win32_Processor");
            foreach (var item in searcher.Get())
            {
                var currentsp = (uint)(item["CurrentClockSpeed"]);
                var clockSpeed = (uint)item["MaxClockSpeed"];
                wsRM.wsMaxClockSpeed = clockSpeed;
                wsRM.wsCurrentClockSpeed = currentsp;
            }

            Console.WriteLine(wsRM.wsCurrentClockSpeed + " Hz");
            Console.WriteLine(wsRM.wsMaxClockSpeed + " Hz");

            Console.Read();
        }
    }

    // Reads the text file
    public class InputData
    {


        public string getData()
        {
            string read;

            try
            {
                // https://www.youtube.com/watch?v=gUjb_HCjsCM
                // And stack overflow

                return read = TextFiles.readtextfiles();

            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                return null;
            }
        }


    }

    public class RateMonotonic
    {
        // Background worker
        public BackgroundWorker m_AsyncWorker = new BackgroundWorker();


        // Start of RateMonotonic Scheduling

        // Declaring public variables we will use
        public int wstime;
        public int wsmaxTime;

        // These are arrays
        public Task[] wsTaskPoolp;
        public Boolean[] wsFinished;
        public int[] wsBurstTime;
        public int[] wsArrivalTime;



        // End of RateMonotonic

        public uint wsCurrentClockSpeed;
        public uint wsMaxClockSpeed;

    }
}
