using Kbg.NppPluginNET.PluginInfrastructure;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Textie;
using Textie.Games;
using static NotepadEmulator.Win32Console;

namespace NotepadEmulator
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //TestInput();
            RunGame();
        }

        static void RunGame()
        {
            Logger.APPEND_LOG = false;
            var logger = new Logger(@"C:\Temp\ConsoleLogger.txt");
            logger.StartLogging();
            var editor = new ScantiliaGateway();
            var notepad = new NotepadGateway();
            var renderer = new ConsoleRenderer(logger);
            Kbg.NppPluginNET.Main.Main2(renderer);
            while (true)
            {

            }
        }

        static void TestInput()
        {
            var keyboard = new Keyboard();
            keyboard.ListenTo(Win32.Win32Keyboard.VirtualKeyStates.VK_RETURN);
            while(true)
            {
                keyboard.Update();
                if (Win32.Win32Keyboard.IsKeyPressed(Win32.Win32Keyboard.VirtualKeyStates.VK_RETURN))
                    break;
            }
        }
    }
}
