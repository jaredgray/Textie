using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Textie.Games.Primitives;

namespace Textie.Games.Scenes
{
    public class LeaderboardScene : Scene
    {
        public LeaderboardScene(IRenderer renderer, Logger logger, Size size, GameData gameData) : base(renderer, logger, size, gameData)
        {
        }
    }
}
