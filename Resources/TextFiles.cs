using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ws_scheduling_hw3_571.Resources
{
    static class TextFiles
    {

        // https://www.youtube.com/watch?v=gUjb_HCjsCM

        public static string readtextfiles()
        {

            // Below you can add new input or text files and just change
            // the name of "input1.txt" to different file to try!

            Assembly assembly = Assembly.GetExecutingAssembly();
            const string NAME = "ws_scheduling_hw3_571.Resources.input1.txt";

            using (Stream stream = assembly.GetManifestResourceStream(NAME))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }

        }
    }
}
