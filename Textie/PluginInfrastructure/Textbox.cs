using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Textie.Games;

namespace Textie.PluginInfrastructure
{
    public class Textbox : Sprite
    {
        const string data = @"|_______________________________________";
        public Textbox(GameData gameData, Scene scene, int width, int height) : base(gameData, scene, width, height)
        {
        }


    }
}
