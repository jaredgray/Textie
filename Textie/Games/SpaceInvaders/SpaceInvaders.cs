using Kbg.NppPluginNET.PluginInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Textie.Games.Audio;
using Textie.Games.SpaceInvaders;
using Textie.TextieInfrastructure;

namespace Textie.Games.Shooter
{
    public class SpaceInvaders : Game
    {
        public SpaceInvaders(INotepadPPGateway npp, IScintillaGateway editor)
            : base(npp, editor)
        {
        }

        public AudioLoop MainAudioPlayer { get; set; }

        //        readonly string PlayerData = @"      /\      
        //     /~~\     
        // ^  /~~~~\  ^ 
        //|------------|
        //|------------|";
        readonly string PlayerData = @"    /\    
 ^ /~~\ ^ 
|--------|
|--------|";
        readonly string AlienData30A = @"{@ @} 
 / \  "; // 1 row
        readonly string AlienData30B = @"{@ @} 
 \ /  "; // 1 row
        readonly string AlienData20A = @" '  ' 
\^/\^/"; // 2 rows
        readonly string AlienData20B = @" '  ' 
/^\/^\"; // 2 rows
        readonly string AlienData10A = @"/[..]\
 |~~| "; // 2 rows
        readonly string AlienData10B = @"/[..]\
 /~~\ "; // 2 rows
        public Player Player { get; set; }

        //public SpriteGroup Alien30 { get; set; }
        //public SpriteGroup Alien20 { get; set; }
        //public SpriteGroup Alien10 { get; set; }

        private TrajectoryController BulletController { get; set; }
        private TrajectoryController AlienController { get; set; }
        private AlienArsenal AlienArsenal { get; set; }
        public CollisionController CollisionController { get; set; }
        public AlienGroupCollisionController AlienGroupCollisionController { get; set; }

        private Bullet CurrentBullet { get; set; }

        protected override void InitializeInternal()
        {
            Logger.WriteLine($"Initializing AsciiShooter...");
            BulletController = new TrajectoryController(GameSize, Logger);
            AlienController = new AlienTrajectoryController(GameSize, Logger);
            CollisionController = new CollisionController();
            AlienGroupCollisionController = new AlienGroupCollisionController();
            AlienArsenal = new AlienArsenal(GameData, BulletController, CollisionController);
            GameData.SetPlayerboard(new Playerboard("/\\", 3));
            SetupAudio();
            BuildCharacters();
        }

        private void SetupAudio()
        {
            MainAudioPlayer = new AudioLoop();
            MainAudioPlayer.AddTrack(new DelayedAudioTrack(Textie.Properties.Resources.SI01)
            {
                DelayType = DelayType.WaitEnd,
                WaitInMilliseconds = 600
            });
            MainAudioPlayer.AddTrack(new DelayedAudioTrack(Textie.Properties.Resources.SI02)
            {
                DelayType = DelayType.WaitEnd,
                WaitInMilliseconds = 600
            });
            MainAudioPlayer.AddTrack(new DelayedAudioTrack(Textie.Properties.Resources.SI03)
            {
                DelayType = DelayType.WaitEnd,
                WaitInMilliseconds = 600
            });
            MainAudioPlayer.AddTrack(new DelayedAudioTrack(Textie.Properties.Resources.SI04)
            {
                DelayType = DelayType.WaitEnd,
                WaitInMilliseconds = 600
            });
        }

        private void BuildCharacters()
        {
            //Player = new Sprite(14, 5)
            Player = new Player(GameData, 10, 4)
            {
                LayerOrder = 0,
                Type = SpriteTypes.PLAYER
            };
            Player.SetData(PlayerData);
            Player.Bounds.Position.X = 45;
            Player.Bounds.Position.Y = 36;
            Player.RendererData.StepX = 2;
            Player.RendererData.StepY = 0;
            base.GameData.Scene.AddSprite(Player);
            GameData.Scene.AddSprite(AlienArsenal);
            BuildAlienGroups();
        }

        private void BuildAlienGroups()
        {

            BuildAlienGroup(3, AlienData30A, AlienData30B, 30);
            BuildAlienGroup(6, AlienData20A, AlienData20B, 20);
            BuildAlienGroup(9, AlienData20A, AlienData20B, 20);
            BuildAlienGroup(12, AlienData10A, AlienData10B, 10);
            BuildAlienGroup(15, AlienData10A, AlienData10B, 10);

        }

        private void BuildAlienGroup(int y, string dataA, string dataB, int worth)
        {

            var group = new AlienGroup(GameData, 20, Primitives.Direction.Right)
            {
                PauseRebuild = true,
                LayerOrder = 1,
                Frequency = 10,
                TrajectoryController = AlienController,
                CollisionController = CollisionController // AlienGroupCollisionController
            };
            group.Bounds.Position.Y = y;
            group.RendererData.StepX = 4;
            for (int i = 0; i < 11; i++)
            {
                BuildAlien(group, dataA, dataB, 8 * i + 5, 0, worth);
            }
            group.PauseRebuild = false;
            group.RebuildData();
            group.Bounds.Size.Lock();
            AlienArsenal.AddAlienGroup(group);
            GameData.Scene.AddSprite(group);
        }

        private void BuildAlien(AlienGroup group, string dataA, string dataB, int xposition, int yposition, int worth)
        {
            var alien = new Alien(GameData, 20, Primitives.Direction.Right, new Primitives.Size(6, 2), worth)
            {
                LayerOrder = 1,
                Frequency = 10,
                TrajectoryController = AlienController,
                Type = SpriteTypes.ALIEN
            };
            alien.SetData(dataA);
            alien.SetData2(dataB);
            alien.Bounds.Position.X = xposition;
            alien.Bounds.Position.Y = yposition;
            group.Add(alien);
        }

        protected override void StartGameLoop()
        {
            MainAudioPlayer.Play();
        }

        protected override void StopGameLoop()
        {
            MainAudioPlayer.Pause();
            IsActive = false;
        }

        protected override void Update()
        {
            if(StopGame)
            {
                if(GameData.Playerboard.HasLife())
                {
                    MainAudioPlayer.Pause();
                    Thread.Sleep(1000);
                    MainAudioPlayer.Play();
                    StopGame = false;
                }
                else
                {
                    StopGameLoop();
                    return;
                }
            }
            if(GameData.PlayerDeath)
            {
                StopGame = true;
                GameData.PlayerDeath = false;
            }

            if(!GameData.Scene.HasSprite(x => x is AlienGroup))
            {
                Thread.Sleep(2000);
                AlienArsenal.Clear();
                BuildAlienGroups();
            }
            
            /*
             
            yeah, this sucks..unfortunately couldn't find a way to listen to key events.
            typical way of doing this by pinvoking the SetWindowsHookEx does not work.
            Instead it just crashes Notepad++. Theres a good chance that it has to do
            with the apartment state or some kind of threading issue.

            also tried turning on the macro recorder from the ScintillaGateway and 
            listening to messages trying to pick out the key characters but that
            doesn't work either. it appeared that since we were writing a lot of 
            spaces to the screen, Scintilla was calling back as if the user was
            pressing the space bar. the arrow heys seemed to work fine but is not
            enough input to play a game

            so here we are.
                
             */
            if (Win32.Keyboard.IsKeyPressed(Win32.Keyboard.VirtualKeyStates.VK_LEFT))
            {
                Player.Bounds.Position.X -= Player.RendererData.StepX;
            }
            if (Win32.Keyboard.IsKeyPressed(Win32.Keyboard.VirtualKeyStates.VK_RIGHT))
            { 
                Player.Bounds.Position.X += Player.RendererData.StepX;
            }
            if (Win32.Keyboard.IsKeyPressed(Win32.Keyboard.VirtualKeyStates.VK_UP))
            {
                Player.Bounds.Position.Y -= Player.RendererData.StepY;
            }
            if (Win32.Keyboard.IsKeyPressed(Win32.Keyboard.VirtualKeyStates.VK_DOWN))
            {
                Player.Bounds.Position.Y += Player.RendererData.StepY;
            }
            if ((null == CurrentBullet || CurrentBullet.MarkDelete) && Win32.Keyboard.IsKeyPressed(Win32.Keyboard.VirtualKeyStates.VK_SPACE))
            {
                CurrentBullet = new Bullet(GameData, 1, Primitives.Direction.Up, Textie.Properties.Resources.SIPB)
                {
                    EdgeOfScreenCondition = EdgeScreenHandling.Disappear,
                    LayerOrder = int.MaxValue,
                    TrajectoryController = BulletController,
                    CollisionController = CollisionController,
                    Type = SpriteTypes.PLAYER_BULLET,
                    CollidesWithTypes = new List<string>() { SpriteTypes.ALIEN, SpriteTypes.ALIEN_BULLET }
                };
                CurrentBullet.RendererData.StepY = 2;
                CurrentBullet.Bounds.Position.X = Player.Bounds.Position.X + 4;
                CurrentBullet.Bounds.Position.Y = Player.Bounds.Position.Y - 1;// move the missile down by one since the game will move it up on the first iteration of drawing
                CurrentBullet.Fire();
                GameData.Scene.AddSprite(CurrentBullet);
            }
        }

    }
}
