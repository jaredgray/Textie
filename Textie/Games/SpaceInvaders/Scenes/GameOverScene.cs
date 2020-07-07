using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Textie.Games.Primitives;

namespace Textie.Games.SpaceInvaders.Scenes
{
    public class GameOverScene : SIScene
    {
        public GameOverScene(IRenderer renderer, Logger logger, Size size, GameData gameData) : base(renderer, logger, size, gameData)
        {
        }

        public override void InitializeScene()
        {
            base.InitializeScene();
            TimeToExit = DateTime.Now.AddSeconds(6);
            BuildCharacters();
        }
        DateTime TimeToExit;
        private void BuildCharacters()
        {
            var gameover = new Sprite(GameData, this, 9, 1);
            gameover.Bounds.Position.X = 55;
            gameover.Bounds.Position.Y = 10;
            gameover.SetData("GAME OVER");
            AddSprite(gameover);
        }

        public override void OnStartScene(Scene lastScene)
        {
            base.OnStartScene(lastScene);
            this.AddSprites(lastScene.QuerySprites(x => true));
        }

        public override void Update()
        {
            base.Update();
            if(DateTime.Now > TimeToExit)
            {
                TimeToExit = DateTime.MaxValue;
                EndScene();
            }
        }
    }
}
