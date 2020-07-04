using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Textie.Games.Audio;
using Textie.Games.Primitives;

namespace Textie.Games.Shooter
{
    public class Bullet : Sprite, ITrajectory, ICollider
    {
        const string data = @"*";
        public Bullet(int frequency, Direction direction, Stream fireSound)
            : base(1, 1)
        {
            Frequency = frequency;
            Direction = direction;
            base.SetData(data);
            CollisionBehavior = CollisionBehavior.Remove;
            Player = new AudioTrackPlayer();
            Player.AddTrack(new AudioTrack(fireSound));
        }

        public AudioTrackPlayer Player { get; set; }

        public int Frequency { get; set; }

        public Direction Direction { get; set; }

        public EdgeScreenHandling EdgeOfScreenCondition { get; set; }
        public TrajectoryRendererData TrajectoryRendererData { get; set; }

        public void Fire()
        {
            Player.Play();
        }

        #region ICollider members

        public void RunDestroySequence()
        {

        }
        public bool HasCollided { get; set; }
        public CollisionBehavior CollisionBehavior { get; set; }

        #endregion
    }
}
