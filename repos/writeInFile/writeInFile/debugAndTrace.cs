using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace writeInFile
{
    internal class debugAndTrace
    {
        public static void debuging(string str)
        {
            Trace.Listeners.Add(new TextWriterTraceListener("debug.txt"));
            Debug.WriteLine(str);
            Trace.Flush();
        }
    }
}
