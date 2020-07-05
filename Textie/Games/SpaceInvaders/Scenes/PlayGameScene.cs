using Kbg.NppPluginNET.PluginInfrastructure;
using System.Collections.Generic;
using System.Threading;
using Textie.Games.Audio;
using Textie.Games.Primitives;
using Textie.Games.Shooter;
using Textie.Games.SpaceInvaders.Scenes;

namespace Textie.Games.SpaceInvaders
{
    public class PlayGameScene : SIScene
    {
        public PlayGameScene(IScintillaGateway editor, Logger logger, Size size, GameData gameData) : base(editor, logger, size, gameData)
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

        public override void InitializeScene()
        {
            Logger.WriteLine($"Initializing AsciiShooter...");
            BulletController = new TrajectoryController(Size, Logger);
            AlienController = new AlienTrajectoryController(Size, Logger);
            CollisionController = new CollisionController();
            AlienGroupCollisionController = new AlienGroupCollisionController();
            AlienArsenal = new AlienArsenal(GameData, this, BulletController, CollisionController);
            SetPlayerboard(new Playerboard("/\\", 3));
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
            Player = new Player(GameData, this, 10, 4)
            {
                LayerOrder = 0,
                Type = SpriteTypes.PLAYER
            };
            Player.SetData(PlayerData);
            Player.Bounds.Position.X = 45;
            Player.Bounds.Position.Y = 36;
            Player.RendererData.StepX = 2;
            Player.RendererData.StepY = 0;
            AddSprite(Player);
            AddSprite(AlienArsenal);
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

            var group = new AlienGroup(GameData, this, 20, Primitives.Direction.Right)
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
            AddSprite(group);
        }

        private void BuildAlien(AlienGroup group, string dataA, string dataB, int xposition, int yposition, int worth)
        {
            var alien = new Alien(GameData, this, 20, Primitives.Direction.Right, new Primitives.Size(6, 2), worth)
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

        public override void Update()
        {
            base.Update();

            if (GameData.StopGame)
            {
                if (Playerboard.HasLife())
                {
                    MainAudioPlayer.Pause();
                    Thread.Sleep(1000);
                    MainAudioPlayer.Play();
                    GameData.StopGame = false;
                }
                else
                {
                    EndScene();

                    return;
                }
            }
            if (GameData.PlayerDeath)
            {
                GameData.StopGame = true;
                GameData.PlayerDeath = false;
            }

            if (!HasSprite(x => x is AlienGroup))
            {
                Thread.Sleep(2000);
                AlienArsenal.Clear();
                BuildAlienGroups();
            }
        }

        public override void GameLoopStarted()
        {
            MainAudioPlayer.Play();
        }

        public override void GameLoopStopped()
        {
            MainAudioPlayer.Pause();
            GameData.IsActive = false;
        }


        #region Key Events

        public override void OnDownKeyDown()
        {
            Player.Bounds.Position.Y += Player.RendererData.StepY;
            if (Win32.Keyboard.IsKeyPressed(Win32.Keyboard.VirtualKeyStates.VK_LEFT))
            {
            }
            if (Win32.Keyboard.IsKeyPressed(Win32.Keyboard.VirtualKeyStates.VK_RIGHT))
            {
            }
            if (Win32.Keyboard.IsKeyPressed(Win32.Keyboard.VirtualKeyStates.VK_UP))
            {
            }
            if (Win32.Keyboard.IsKeyPressed(Win32.Keyboard.VirtualKeyStates.VK_DOWN))
            {
            }
            if (Win32.Keyboard.IsKeyPressed(Win32.Keyboard.VirtualKeyStates.VK_SPACE))
            {
            }
        }

        public override void OnLeftKeyDown()
        {
            Player.Bounds.Position.X -= Player.RendererData.StepX;
        }

        public override void OnRightKeyDown()
        {
            Player.Bounds.Position.X += Player.RendererData.StepX;
        }

        public override void OnUpKeyDown()
        {
            Player.Bounds.Position.Y -= Player.RendererData.StepY;
        }

        public override void OnSpaceKeyDown()
        {
            if((null == CurrentBullet || CurrentBullet.MarkDelete))
            {
                CurrentBullet = new Bullet(GameData, this, 1, Primitives.Direction.Up, Textie.Properties.Resources.SIPB)
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
                AddSprite(CurrentBullet);
            }
        }

        #endregion

    }
}
