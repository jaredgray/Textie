using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Kbg.NppPluginNET.PluginInfrastructure;
using Textie;

namespace Kbg.NppPluginNET
{
    public class Main
    {
        internal const string PluginName = "Textie";
        static IScintillaGateway editor;
        static INotepadPPGateway notepad;
        public static readonly int COMMAND_SORT = 0;

        static IntPtr CurrentWindowId;


        static Main()
        {
            editor = new ScintillaGateway(PluginBase.GetCurrentScintilla());
            notepad = new NotepadPPGateway();

        }


        /// <summary>
        /// handles messages sent from Notepad++ or another application
        /// </summary>
        /// <param name="notification"></param>
        public static void OnNotification(ScNotification notification)
        {
        }

        public static void CommandMenuInit()
        {
            PluginBase.SetCommand(COMMAND_SORT, "Sort (case insensitive)", SortCaseInsensitive, new ShortcutKey(false, false, false, Keys.None));
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

        private static void SortCaseInsensitive()
        {
            try
            {
                var textlist = GetTextFromEditorAsDictionary();
                textlist.Sort();
                editor.ClearAll();
                foreach (var item in textlist)
                {
                    AddTextToEditor(item.Item2);
                }
            }
            catch (Exception ex)
            {
                Fail(ex);
            }
        }

        private static TupleList<string, string> GetTextFromEditorAsDictionary()
        {
            var requestLength = int.MaxValue;
            var currentText = editor.GetText(requestLength);
            var textlist = new TupleList<string, string>();
            using (StringReader sr = new StringReader(currentText))
            {
                string line = null;
                while (null != (line = sr.ReadLine()))
                {
                    textlist.Add(line.ToUpper(), line);
                }
            }
            return textlist;
        }

        private static void AddTextToEditor(string text)
        {
            editor.AddText(text.Length, text);
            editor.NewLine();
        }

        private static void Try(Action action, bool showError = true)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                if (showError)
                    Fail(ex);
            }
        }

        private static void Fail(Exception ex)
        {
            notepad.FileNew();
            var exmsg = ex.ToString();
            editor.AppendText(exmsg.Length, exmsg);
            editor.NewLine();
        }

    }
}