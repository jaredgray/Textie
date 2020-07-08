﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Kbg.NppPluginNET.PluginInfrastructure;
using Textie;
using Textie.Games;
using Textie.Games.Renderers;
using Textie.Games.Services;
using Textie.Games.Shooter;

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

        //static SpaceInvaders shootergame;
        static IntPtr CurrentWindowId;
        static Dictionary<IntPtr, SpaceInvaders> spaceInvaderGames;
        static NppRenderer NppRenderer;


        static Main()
        {
            spaceInvaderGames = new Dictionary<IntPtr, SpaceInvaders>();
            editor = new ScintillaGateway(PluginBase.GetCurrentScintilla());
            notepad = new NotepadPPGateway();
            logger = new Logger(@"C:\Temp\TextieLog.txt");
            NppRenderer = new NppRenderer(notepad, editor, logger);
            editor.StartRecord();
            logger.StartLogging();

        }

        /// <summary>
        /// entry point for an application other than Notepad++. this allows another application to run and even render the game
        /// </summary>
        /// <param name="pEditor"></param>
        /// <param name="pNotepad"></param>
        public static void Main2(IRenderer renderer)
        {
            var service = new LeaderboardService();
            var game = new SpaceInvaders(renderer, service);
            spaceInvaderGames.Add(IntPtr.Zero, game);
            game.Initialize();
            game.Run();
        }

        /// <summary>
        /// handles messages sent from Notepad++ or another application
        /// </summary>
        /// <param name="notification"></param>
        public static void OnNotification(ScNotification notification)
        {
            // get document pointer and notify game
            var newWindowId = editor.GetDocPointer();

            //if (notification.Header.Code == (uint)NppMsg.NPPN_FILEBEFORECLOSE)
            //{
            //    if (spaceInvaderGames.TryGetValue(newWindowId, out var game))
            //    {
            //        game.Quit = true;
            //        game.GameData.IsActive = game.GameData.IsAlive = false;
            //        notepad.CloseCurrent();
            //    }
            //}
            if (newWindowId != CurrentWindowId)
            {
                // TODO: when new games are added the below code should be abstracted so we don't have to check a bunch of different dictionaries for different games
                if (spaceInvaderGames.TryGetValue(CurrentWindowId, out var game))
                {
                    if (game.GameData.IsActive && !game.GameData.StopGame)
                    {
                        // Pause the game
                        logger.WriteLine($"{CurrentWindowId}-{DateTime.Now} Pausing Game");
                        game.GameData.IsActive = false;
                    }
                }
            }
            else if (newWindowId == CurrentWindowId)
            {
                // TODO: when new games are added the below code should be abstracted so we don't have to check a bunch of different dictionaries for different games
                if (spaceInvaderGames.TryGetValue(newWindowId, out var game))
                {
                    if (!game.GameData.IsActive && !game.GameData.StopGame)
                    {
                        // Un-Pause the game
                        logger.WriteLine($"{newWindowId}-{DateTime.Now} Resuming Game");
                        game.GameData.IsActive = true;
                    }
                    if (game.Quit)
                    {
                        game.Quit = false;
                        spaceInvaderGames.Remove(newWindowId);
                        notepad.CloseCurrent();
                    }
                }
            }

            //var action = "";
            //Try(() => action = Enum.GetName(typeof(NppMsg), notification.Header.Code), false);
            //if(string.IsNullOrEmpty(action))
            //    Try(() => action = Enum.GetName(typeof(SciMsg), notification.Header.Code), false);


            //if (spaceInvaderGames.TryGetValue(newWindowId, out var game))
            //{
            //    /*
            //     1003 - 2667773762896 - NPPN_FILEBEFORECLOSE - -2147483648 - 1638448
            //     */
            //    if (notification.Header.Code == (uint)NppMsg.NPPN_FILEBEFORECLOSE)
            //    {
            //        shootergame.NotifyBeforeWindowClose(docpointer);
            //    }
            //}

            /* 
             * 4294966745 is the code sent just before the window changes
             * 
             * 4294966745 - 2481992418880 -  - 0 - 459584
             * */
            //var scimsg = Enum.GetName(typeof(SciMsg), notification.Header.Code);
            //Try(() => logger.WriteLine($"{notification.Header.Code} - {scimsg} - {notification.lParam}, {notification.wParam}, {notification.character}, {notification.Character}, {notification.Header.IdFrom}"), false);

            CurrentWindowId = newWindowId;
        }

        public static void CommandMenuInit()
        {
            PluginBase.SetCommand(COMMAND_SORT, "Sort (case insensitive)", SortCaseInsensitive, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand(COMMAND_PLAYSHOOTER, "Play Space Invaders", PlaySpaceInvadersGame, new ShortcutKey(false, false, false, Keys.None));
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

        private static void PlaySpaceInvadersGame()
        {
            //notepad.FileNew();
            var service = new LeaderboardService();
            var game = new SpaceInvaders(NppRenderer, service);
            game.Initialize();
            var windowId = editor.GetDocPointer();
            spaceInvaderGames.Add(windowId, game);
            game.Run();
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