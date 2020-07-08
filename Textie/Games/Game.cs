﻿using Kbg.NppPluginNET.PluginInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Windows.Input;
using Textie.Games.Primitives;
using Textie.Games.Services;

namespace Textie.Games
{
    public abstract class Game<TScene, TGameData>
        where TScene : Scene
        where TGameData : GameData
    {
        public int UpdateRateInMilliseconds { get; set; }
        public static bool DO_LOG = true;
        protected IRenderer Renderer { get; private set; }
        internal Logger Logger { get; set; }

        public bool Quit { get; set; }

        public TGameData GameData { get; set; }
        public TScene Scene { get; set; }
     

        #region Game variables 

        protected Size GameSize { get; }

        private bool IsInitialized { get; set; }
        private Thread GameThread;

        #endregion

        public Game(IRenderer renderer, ILeaderboardService leaderboardService)
        {
            Quit = false;
            Renderer = renderer;
            Logger = new Logger(@"C:\Temp\TextieGameLog.txt");
            UpdateRateInMilliseconds = 5;
            GameSize = new Size()
            {
                Height = 40,
                Width = 128
            };
            CreateGameData(leaderboardService);
        }

        public void Initialize()
        {
            if (!IsInitialized)
            {
                Try(() =>
                {

                    IsInitialized = true;
                    GameData.IsAlive = GameData.IsActive = true;
                    Logger.StartLogging();
                    InitializeInternal();
                    Renderer.Initialize(GameSize);
                    //Scene.ini
                });
            }
        }

        public void Run()
        {
            GameThread = new Thread(new ThreadStart(GameLoop));
            GameThread.Start();
        }

        private void GameLoop()
        {
            if (DO_LOG)
            {
                Logger.WriteLine($"Beginning Game Loop."); // WindowId: {WindowId}");
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
            Quit = true;
        }

        private void GameLoopIteration()
        {
            Try(() =>
            {
                ++Textie.Games.GameData.FrameSequence;
                GameData.Keyboard.Update();
                Update();
                Scene.Update();
                Scene.Draw();
                Thread.Sleep(UpdateRateInMilliseconds);
                CheckForQuit();
            });
        }

        private void CheckForQuit()
        {
            if (GameData.Keyboard.IsKeyDown(Win32.Win32Keyboard.VirtualKeyStates.VK_ESCAPE))
            //if (GameData.Keyboard.IsKeyDown(ConsoleKey.Escape))
            {
                GameData.IsActive = GameData.IsAlive = false;
            }
        }

        private void CleanupGame()
        {
            //GameThread.Abort();
            GameData.IsAlive = false;
            GameData.IsActive = false;
            StopGameLoop();
            Scene.GameLoopStopped();
            // TODO: need a way to log the instance information (windowid or whatever)
            //Logger.WriteLine($"{WindowId}-{DateTime.Now} CleanupGame()");
            Logger.WriteLine($"{DateTime.Now} CleanupGame()");
            Logger.StopLogging();
            Logger = null;
        }


        #region Abstract interface
        
        public abstract string GameId { get; }

        protected abstract void InitializeInternal();
        protected abstract void StartGameLoop();
        protected abstract void StopGameLoop();
        protected abstract void ChangeScene();
        protected abstract void Update();

        protected abstract void CreateGameData(ILeaderboardService leaderboardService);

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
            var exmsg = ex.ToString() + Environment.NewLine;
            Renderer.PreRenderFrame();
            var carr = exmsg.ToArray();
            var barr = new byte[carr.Length];
            for (int i = 0; i < carr.Length; i++)
            {
                barr[i] = (byte)carr[i];
            }
            Renderer.RenderFrame(barr);
        }
    }
}
