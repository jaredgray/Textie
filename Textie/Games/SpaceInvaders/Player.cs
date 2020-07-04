using System.Collections.Generic;
using Textie.Games.Audio;
using Textie.Games.Primitives;
using Textie.Games.Shooter;

namespace Textie.Games.SpaceInvaders
{
    public class Player : Sprite, ICollider
    {
        const string data = @"COME ON!!!!!";
        public Player(GameData gameData, int width, int height)
            : base(gameData, width, height)
        {
            base.SetData(data);
            CollisionBehavior = CollisionBehavior.RunDestroySequence;
            DeathPlayer = new AudioTrackPlayer();
            DeathPlayer.AddTrack(new AudioTrack(Textie.Properties.Resources.SIPD));
            CollidesWithTypes = new List<string>() { SpriteTypes.ALIEN, SpriteTypes.ALIEN_BULLET };
        }

        private AudioTrackPlayer DeathPlayer { get; set; }

        #region ICollider members

        public void RunDestroySequence()
        {
            // we don't actually want to delete the player
            DeathPlayer.Play();
            GameData.Playerboard.RemoveLife();
            GameData.PlayerDeath = true;
        }
        // disable the collided property because the player continues until the game detects that the player had died
        public bool HasCollided { get { return false; } set { } }
     
        public CollisionBehavior CollisionBehavior { get; set; }
        public IEnumerable<string> CollidesWithTypes { get; set; }

        #endregion
    }
}
