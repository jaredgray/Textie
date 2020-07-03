using Kbg.NppPluginNET.PluginInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Textie;
using Textie.Games;

namespace NotepadEmulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.APPEND_LOG = false;
            var editor = new ScantiliaGateway();
            var notepad = new NotepadGateway();
            Kbg.NppPluginNET.Main.Main2(editor, notepad);
            Kbg.NppPluginNET.Main.CommandMenuInit();
            PluginBase._funcItems.Items[Kbg.NppPluginNET.Main.COMMAND_PLAYSHOOTER]._pFunc.Invoke();
            Stage.DO_LOG = true;
            while (true)
            {

            }
        }
    }
}
