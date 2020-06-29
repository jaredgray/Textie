using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Textie
{
    public class Logger
    {
        public Logger(string logPath)
        {
            LogPath = logPath;
            Directory.CreateDirectory(Path.GetDirectoryName(logPath));
        }
        public string LogPath { get; set; }

        StreamWriter sw = null;

        public void StartLogging()
        {
            if(null == sw)
            {
                sw = new StreamWriter(LogPath, true)
                {
                    AutoFlush = true
                };
            }
        }

        public void StopLogging()
        {
            sw.Close();
            sw.Dispose();
            sw = null;
        }

        public void WriteLine(string text)
        {
            if(null != sw)
            {
                try
                {
                    sw.WriteLine(text);
                }
                catch
                {
                }
            }
        }
    }
}
