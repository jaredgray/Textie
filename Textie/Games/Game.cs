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
    public abstract class Game<TScene>
        where TScene : Scene
    {
        public int UpdateRateInMilliseconds { get; set; }
        public static bool DO_LOG = true;
        protected IntPtr WindowId = IntPtr.Zero;
        protected INotepadPPGateway Npp { get; private set; }
        protected IScintillaGateway Editor { get; private set; }
        internal Logger Logger { get; set; }


        protected GameData GameData { get; set; }
        public TScene Scene { get; set; }


        #region Game variables 

        protected Size GameSize { get; }

        private bool IsInitialized { get; set; }
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
            // TODO: Scenes should be loaded from an inheriting game object which decides what happens in it's scenes
            GameData = new GameData
            {
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
                    GameData.IsAlive = GameData.IsActive = true;
                    Logger.StartLogging();
                    InitializeInternal();
                    //Scene.ini
                    GameThread = new Thread(new ThreadStart(GameLoop));
                    GameThread.Start();
                });
            }
        }

        public void NotifyCurrentWindow(IntPtr windowId)
        {
            /*
                The point of this method is to hadle when the user switches tabs. if we don't
                stop the game loop the game will continue to draw onto the tab the user switched into.
                The variable StopGame is used for the inheriting game to force the game to stop. 
                Since this is called over and over from the NPP message loop you can't just set the 
                IsActiveFlag to false since windowId == WindowId && !IsActive will evaluate to true
                which would just activate the game again
             */
            if (GameData.IsAlive)
            {
                if (windowId != WindowId && GameData.IsActive && !GameData.StopGame)
                {
                    if (DO_LOG)
                    {
                        Logger.WriteLine($"{WindowId}-{DateTime.Now} Pausing Game");
                    }
                    GameData.IsActive = false;
                }
                else if (windowId == WindowId && !GameData.IsActive && !GameData.StopGame)
                {
                    if (DO_LOG)
                    {
                        Logger.WriteLine($"{WindowId}-{DateTime.Now} Resuming Game");
                    }
                    GameData.IsActive = true;
                }
            }
        }

        public bool NotifyBeforeWindowClose(IntPtr windowId)
        {
            if (windowId == WindowId)
            {
                GameData.IsActive = GameData.IsAlive = false;              
                //CleanupGame();
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
            // TODO: change scene should exist within the game loop. need some detection method to determine when it needs changed
            //       or possibly just let the inheriting game figure this out
            ChangeScene();
            StartGameLoop();
            Scene.GameLoopStarted();
            while (GameData.IsAlive)
            {
                if (GameData.IsActive)
                {
                    GameLoopIteration();
                }
            }
            CleanupGame();
        }

        private void GameLoopIteration()
        {
            Try(() =>
            {
                Update();
                Scene.Update();
                Scene.Draw();
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
            GameData.IsAlive = false;
            GameData.IsActive = false;
            StopGameLoop();
            Scene.GameLoopStopped();
            Logger.WriteLine($"{WindowId}-{DateTime.Now} CleanupGame()");
            Logger.StopLogging();
            Logger = null;
        }


        #region Abstract class methods 

        protected abstract void InitializeInternal();
        protected abstract void StartGameLoop();
        protected abstract void StopGameLoop();
        protected abstract void ChangeScene();
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
            GameData.IsAlive = GameData.IsActive = false;
            Npp.FileNew();
            var exmsg = ex.ToString();
            Editor.AppendText(exmsg.Length, exmsg);
            Editor.NewLine();
        }
    }
}
