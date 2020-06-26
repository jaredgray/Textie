using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Kbg.NppPluginNET.PluginInfrastructure;

namespace Kbg.NppPluginNET
{
    class Main
    {
        internal const string PluginName = "Textie";
        //static frmMyDlg frmMyDlg = null;
        static readonly IScintillaGateway editor = new ScintillaGateway(PluginBase.GetCurrentScintilla());


        public static void OnNotification(ScNotification notification)
        {  
            // This method is invoked whenever something is happening in notepad++
            // use eg. as
            // if (notification.Header.Code == (uint)NppMsg.NPPN_xxx)
            // { ... }
            // or
            //
            // if (notification.Header.Code == (uint)SciMsg.SCNxxx)
            // { ... }
        }

        internal static void CommandMenuInit()
        {
            PluginBase.SetCommand(0, "Sort (case insensitive)", SortCaseInsensitive, new ShortcutKey(false, false, false, Keys.None));
        }

        internal static void SetToolBarIcon()
        {
            //toolbarIcons tbIcons = new toolbarIcons();
            //tbIcons.hToolbarBmp = tbBmp.GetHbitmap();
            //IntPtr pTbIcons = Marshal.AllocHGlobal(Marshal.SizeOf(tbIcons));
            //Marshal.StructureToPtr(tbIcons, pTbIcons, false);
            //Win32.SendMessage(PluginBase.nppData._nppHandle, (uint) NppMsg.NPPM_ADDTOOLBARICON, PluginBase._funcItems.Items[idMyDlg]._cmdID, pTbIcons);
            //Marshal.FreeHGlobal(pTbIcons);
        }

        internal static void PluginCleanUp()
        {
        }


        internal static void SortCaseInsensitive()
        {
            var requestLength = int.MaxValue;
            var currentText = editor.GetText(requestLength);
            var textlist = new Dictionary<string, string>();
            using(StringReader sr = new StringReader(currentText))
            {
                string line = null;
                while(null != (line = sr.ReadLine()))
                {
                    textlist.Add(line.ToUpper(), line);
                }
            }
            var sorted = textlist.Keys.ToList();
            sorted.Sort();
            editor.ClearAll();
            foreach (var key in sorted)
            {
                editor.AddText(textlist[key].Length, textlist[key]);
                editor.NewLine();
            }
        }

    }
}