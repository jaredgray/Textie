using Kbg.NppPluginNET.PluginInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Input;
using Textie.Games.Primitives;

namespace Textie.Games
{
    public abstract class Game
    {
        public int UpdateRateInMilliseconds { get; set; }
        public static bool DO_LOG = true;
        protected IntPtr WindowId = IntPtr.Zero;
        protected INotepadPPGateway Npp { get; private set; }
        protected IScintillaGateway Editor { get; private set; }
        internal Logger Logger { get; set; }


        protected GameData GameData { get; set; }

        #region Game variables 

        protected Size GameSize { get; }

        private bool IsInitialized { get; set; }
        protected bool IsAlive { get; set; }
        protected bool IsActive { get; set; }
        private Thread GameThread;

        #endregion

        public Game(INotepadPPGateway npp, IScintillaGateway editor)
        {
            Npp = npp;
            Editor = editor;
            Logger = new Logger(@"C:\Temp\TextieGameLog.txt");
            UpdateRateInMilliseconds = 60;
            GameSize = new Size()
            {
                Height = 40,
                Width = 128
            };
            GameData = new GameData
            {
                Stage = new Stage(editor, Logger, GameSize)
            };
        }

        public void Initialize()
        {
            if (!IsInitialized)
            {
                Try(() =>
                {
                    IsInitialized = true;
                    Npp.FileNew();
                    WindowId = Editor.GetDocPointer();
                    IsAlive = IsActive = true;
                    Logger.StartLogging();
                    InitializeInternal();
                    GameThread = new Thread(new ThreadStart(GameLoop));
                    GameThread.Start();
                });
            }
        }

        public void NotifyCurrentWindow(IntPtr windowId)
        {
            if (IsAlive)
            {
                if (windowId != WindowId && IsActive)
                {
                    if (DO_LOG)
                    {
                        Logger.WriteLine($"{WindowId}-{DateTime.Now} Pausing Game");
                    }
                    IsActive = false;
                    this.StopGameLoop();
                }
                else if (windowId == WindowId && !IsActive)
                {
                    if (DO_LOG)
                    {
                        Logger.WriteLine($"{WindowId}-{DateTime.Now} Resuming Game");
                    }
                    IsActive = true;
                    this.StartGameLoop();
                }
            }
        }

        public bool NotifyBeforeWindowClose(IntPtr windowId)
        {
            if (windowId == WindowId)
            {
                CleanupGame();
                return true;
            }
            return false;
        }

        private void GameLoop()
        {
            if (DO_LOG)
            {
                Logger.WriteLine($"Beginning Game Loop. WindowId: {WindowId}");
            }
            StartGameLoop();
            while (IsAlive)
            {
                if (IsActive)
                {
                    GameLoopIteration();
                }
            }
        }

        private void GameLoopIteration()
        {
            Try(() =>
            {
                Update();
                GameData.Stage.Draw();
                Thread.Sleep(UpdateRateInMilliseconds);
                //SlowGameLoop();
            });
        }

        private void SlowGameLoop()
        {
            Logger.WriteLine($"{WindowId}-{DateTime.Now} GameLoopIteration()");
            Thread.Sleep(1000);
        }

        private void CleanupGame()
        {
            IsAlive = false;
            IsActive = false;
            StopGameLoop();
            Logger.WriteLine($"{WindowId}-{DateTime.Now} CleanupGame()");
            Logger.StopLogging();
            Logger = null;
        }


        #region Abstract class methods 

        protected abstract void InitializeInternal();
        protected abstract void StartGameLoop();
        protected abstract void StopGameLoop();

        protected abstract void Update();


        #endregion


        protected void Try(Action action, bool showError = true)
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

        protected void Fail(Exception ex)
        {
            IsAlive = IsActive = false;
            Npp.FileNew();
            var exmsg = ex.ToString();
            Editor.AppendText(exmsg.Length, exmsg);
            Editor.NewLine();
        }
    }
}
