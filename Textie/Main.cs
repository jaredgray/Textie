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
using Textie;
using Textie.Games;
using Textie.Games.Shooter;
using Textie.TextieInfrastructure;

namespace Kbg.NppPluginNET
{
    public class Main
    {
        internal const string PluginName = "Textie";
        //static frmMyDlg frmMyDlg = null;
        static IScintillaGateway editor;
        static INotepadPPGateway notepad;
        static Logger logger;

        public static readonly int COMMAND_SORT = 0;
        public static readonly int COMMAND_PLAYSHOOTER = 1;
        public static readonly int COMMAND_STARTLOGGING = 2;
        public static readonly int COMMAND_ENDLOGGING = 3;

        static AsciiShooter shootergame;

        static StreamWriter sw;

        static Main()
        {
            editor = new ScintillaGateway(PluginBase.GetCurrentScintilla());
            notepad = new NotepadPPGateway();
            shootergame = new AsciiShooter(notepad, editor);
            logger = new Logger(@"C:\Temp\TextieLog.txt");
            editor.StartRecord();
        }

        public static void Main2(IScintillaGateway pEditor, INotepadPPGateway pNotepad)
        {
            editor = null;
            notepad = null;
            shootergame = null;

            editor = pEditor;
            notepad = pNotepad;
            shootergame = new AsciiShooter(notepad, editor);
        }

        public static void OnNotification(ScNotification notification)
        {
            // This method is invoked whenever something is happening in notepad++
            // use eg. as
            //if (notification.Header.Code == (uint)NppMsg.)
            //{

            //}
            // or
            //
            // if (notification.Header.Code == (uint)SciMsg.SCNxxx)
            // { ... }

            // get doc pointer
            var docpointer = editor.GetDocPointer();
            shootergame.NotifyCurrentWindow(docpointer);

            var action = "";
            Try(() => action = Enum.GetName(typeof(NppMsg), notification.Header.Code), false);
            if(string.IsNullOrEmpty(action))
                Try(() => action = Enum.GetName(typeof(SciMsg), notification.Header.Code), false);


            /*
             1003 - 2667773762896 - NPPN_FILEBEFORECLOSE - -2147483648 - 1638448
             */
            if (notification.Header.Code == (uint)NppMsg.NPPN_FILEBEFORECLOSE)
            {
                shootergame.NotifyBeforeWindowClose(docpointer);
            }
            else if(notification.Header.Code == (uint)SciMsg.SCN_MACRORECORD)
            {
                var key = (SciKeys)notification.lParam;
                KeyboarEventBroadcaster.FireKeyDown(key);

                Try(() => logger.WriteLine($"{docpointer} - {action} - {notification.lParam} - {Enum.GetName(typeof(SciKeys), key)}"), false);
            }

            /* 
             * 4294966745 is the code sent just before the window changes
             * 
             * 4294966745 - 2481992418880 -  - 0 - 459584
             * */
            //Try(() => logger.WriteLine($"{notification.Header.Code} - {docpointer} - {action} - {notification.Message} - {notification.Header.hwndFrom}"), false);

        }

        public static void CommandMenuInit()
        {
            PluginBase.SetCommand(COMMAND_SORT, "Sort (case insensitive)", SortCaseInsensitive, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand(COMMAND_PLAYSHOOTER, "Play Shooter", PlayShooterGame, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand(COMMAND_STARTLOGGING, "DEV - Start Logging", BeginLogging, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand(COMMAND_ENDLOGGING, "DEV - END Logging", EndLogging, new ShortcutKey(false, false, false, Keys.None));
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

        #region Logging

        internal static void BeginLogging()
        {
            Try(() => logger.StartLogging());
        }

        internal static void EndLogging()
        {
            Try(() => logger.StopLogging());
        }

        #endregion

        internal static void SortCaseInsensitive()
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

        internal static void PlayShooterGame()
        {
            shootergame.Initialize();
        }


        static TupleList<string, string> GetTextFromEditorAsDictionary()
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

        static void AddTextToEditor(string text)
        {
            editor.AddText(text.Length, text);
            editor.NewLine();
        }

        static void Try(Action action, bool showError = true)
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

        static void Fail(Exception ex)
        {
            notepad.FileNew();
            var exmsg = ex.ToString();
            editor.AppendText(exmsg.Length, exmsg);
            editor.NewLine();
        }

    }
}