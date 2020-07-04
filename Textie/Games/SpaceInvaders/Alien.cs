using System.Collections.Generic;
using Textie.Games.Audio;
using Textie.Games.Primitives;
using Textie.Games.Shooter;

namespace Textie.Games.SpaceInvaders
{
    public class Alien : Sprite, ITrajectory, ICollider
    {
        const string data = @"COME ON!!!!!";
        public Alien(GameData gameData, int frequency, Direction direction, Size size, int worth)
            : base(gameData, size.Width, size.Height)
        {
            this.Worth = worth;
            Frequency = frequency;
            Direction = direction;
            base.SetData(data);
            DataIndex = 1; // set data index to 1 so it will flip back to 0 on first draw
            CollisionBehavior = CollisionBehavior.RunDestroySequence;
            DeathPlayer = new AudioTrackPlayer();
            DeathPlayer.AddTrack(new AudioTrack(Textie.Properties.Resources.SIAD));
            CollidesWithTypes = new List<string>() { SpriteTypes.PLAYER, SpriteTypes.PLAYER_BULLET };
        }

        public int Worth { get; set; }
        private Bullet AlienBullet { get; set; }
        private AudioTrackPlayer DeathPlayer { get; set; }

        public override bool MarkDelete
        {
            get
            {
                return _markDelete;
            }
            set
            {
                if(_markDelete != value)
                {
                    if(value)
                    {
                        GameData.Playerboard.AddPoints(this.Worth);
                    }
                    _markDelete = value;
                }
            }
        }
        private bool _markDelete;

        private int DataIndex { get; set; }

        public List<char> Data2 { get; set; }
        public void SetData2(string data)
        {
            Data2 = new List<char>();
            base.SetData(Data2, data);
        }

        public int Frequency { get; set; }

        public Direction Direction { get; set; }

        public EdgeScreenHandling EdgeOfScreenCondition { get; set; }
        public TrajectoryRendererData TrajectoryRendererData { get; set; }

        public override void Update()
        {
            base.Update();
            ++DataIndex;
            if (DataIndex > 1)
                DataIndex = 0;
        }
        public override char GetCharAt(int index)
        {
            if(DataIndex == 0)
            {
                if (index < Data.Count)
                {
                    return Data[index];
                }
                else
                {

                }
            }
            else
            {
                if (index < Data2.Count)
                {
                    return Data2[index];
                }
                else
                {

                }
            }
            return ' ';
        }

        public void FireAtWill(TrajectoryController bulletController, ICollisionController collisionController, int offsetY)
        {

            var bullet = new Bullet(GameData, 1, Primitives.Direction.Up, Textie.Properties.Resources.SIAB)
            {
                EdgeOfScreenCondition = EdgeScreenHandling.Disappear,
                LayerOrder = int.MaxValue,
                TrajectoryController = bulletController,
                CollisionController = collisionController,
                Direction = Direction.Down,
                Type = SpriteTypes.ALIEN_BULLET,
                CollidesWithTypes = new List<string>() { SpriteTypes.PLAYER, SpriteTypes.PLAYER_BULLET }
            };
            bullet.SetData("!");
            bullet.RendererData.StepY = 2;
            bullet.Bounds.Position.X = this.Bounds.Position.X + 3;
            bullet.Bounds.Position.Y = offsetY + this.Bounds.Position.Y + 3;// move the missile down by one since the game will move it up on the first iteration of drawing
            bullet.Fire();
            GameData.Scene.AddSprite(bullet);
        }

        #region ICollider members

        public void RunDestroySequence()
        {
            this.MarkDelete = true;
            DeathPlayer.Play();
        }
        public bool HasCollided { get; set; }
        public CollisionBehavior CollisionBehavior { get; set; }
        public IEnumerable<string> CollidesWithTypes { get; set; }

        #endregion
    }
}
