using Kbg.NppPluginNET.PluginInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
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
        public Sprite Player { get; set; }

        //public SpriteGroup Alien30 { get; set; }
        //public SpriteGroup Alien20 { get; set; }
        //public SpriteGroup Alien10 { get; set; }

        private TrajectoryController BulletController { get; set; }
        private TrajectoryController AlienController { get; set; }

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
            Player = new Sprite(10, 4)
            {
                LayerOrder = 0
            };
            Player.SetData(PlayerData);
            Player.Bounds.Position.X = 45;
            Player.Bounds.Position.Y = 36;
            Player.RendererData.StepX = 2;
            Player.RendererData.StepY = 0;
            base.GameData.Stage.AddSprite(Player);

            BuildAlienGroup(3, AlienData30A, AlienData30B);
            BuildAlienGroup(6, AlienData20A, AlienData20B);
            BuildAlienGroup(9, AlienData20A, AlienData20B);
            BuildAlienGroup(12, AlienData10A, AlienData10B);
            BuildAlienGroup(15, AlienData10A, AlienData10B);
        }

        private void BuildAlienGroup(int y, string dataA, string dataB)
        {

            var group = new AlienGroup(20, Primitives.Direction.Right)
            {
                PauseRebuild = true,
                LayerOrder = 1,
                Frequency = 10,
                TrajectoryController = AlienController,
                CollisionController = AlienGroupCollisionController
            };
            group.Bounds.Position.Y = y;
            group.RendererData.StepX = 4;
            for (int i = 0; i < 11; i++)
            {
                BuildAlien(group, dataA, dataB, 8 * i + 5, 0);
            }
            group.PauseRebuild = false;
            group.RebuildData();
            group.Bounds.Size.Lock();
            GameData.Stage.AddSprite(group);
        }

        private void BuildAlien(AlienGroup group, string dataA, string dataB, int xposition, int yposition)
        {
            var alien = new Alien(20, Primitives.Direction.Right, new Primitives.Size(6, 2))
            {
                LayerOrder = 1,
                Frequency = 10,
                TrajectoryController = AlienController
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
        }

        protected override void Update()
        {
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
                CurrentBullet = new Bullet(1, Primitives.Direction.Up, Textie.Properties.Resources.SIPB)
                {
                    EdgeOfScreenCondition = EdgeScreenHandling.Disappear,
                    LayerOrder = int.MaxValue,
                    TrajectoryController = BulletController,
                    CollisionController = CollisionController
                };
                CurrentBullet.RendererData.StepY = 2;
                CurrentBullet.Bounds.Position.X = Player.Bounds.Position.X + 4;
                CurrentBullet.Bounds.Position.Y = Player.Bounds.Position.Y - 1;// move the missile down by one since the game will move it up on the first iteration of drawing
                CurrentBullet.Fire();
                GameData.Stage.AddSprite(CurrentBullet);
            }
        }

    }
}
