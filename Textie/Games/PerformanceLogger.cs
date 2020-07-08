using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Textie.Games
{
    public class PerformanceLogger
    {
        public PerformanceLogger(string fileName)
        {
            Watch = new Stopwatch();
            PerfLogger = new Logger(Path.Combine(@"C:\Temp", fileName));
            PerfLogger.StartLogging();
        }

        readonly Stopwatch Watch;
        readonly Logger PerfLogger;

        public void Start()
        {
            Watch.Reset();
            Watch.Start();
        }


        public void Log(string message)
        {
            PerfLogger.WriteLine(message);
        }

        public void Stop()
        {
            Watch.Stop();
            PerfLogger.WriteLine($"{GameData.FrameSequence:00000}: {Watch.ElapsedMilliseconds}");
        }
    }
}
