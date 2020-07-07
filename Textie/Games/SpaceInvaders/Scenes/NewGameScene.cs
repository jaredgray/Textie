﻿using Kbg.NppPluginNET.PluginInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Textie.Games.Audio;
using Textie.Games.Primitives;
using Textie.Games.SpaceInvaders;
using Textie.Games.SpaceInvaders.Scenes;
using Textie.TextieInfrastructure;

namespace Textie.Games.SpaceInvaders
{
    public class NewGameScene : SIScene
    {
        public NewGameScene(IRenderer renderer, Logger logger, Size size, GameData gameData) : base(renderer, logger, size, gameData)
        {
        }

        public override void InitializeScene()
        {
            base.InitializeScene();
            CanUpdate = true;
            BuildCharacters();
        }

        public bool CanUpdate { get; set; }
        private void BuildCharacters()
        {
            var gameover = new Sprite(GameData, this, 20, 1);
            gameover.Bounds.Position.X = 55;
            gameover.Bounds.Position.Y = 10;
            gameover.SetData("PRESS ENTER TO START");
            AddSprite(gameover);

            var esc = new Sprite(GameData, this, 32, 1);
            esc.Bounds.Position.X = 49;
            esc.Bounds.Position.Y = 12;
            esc.SetData("PRESS ESCAPE AT ANY TIME TO EXIT");
            AddSprite(esc);
        }

        public override void OnStartScene(Scene lastScene)
        {

        }

        public override void Update()
        {
            base.Update();
            if(CanUpdate && GameData.Keyboard.IsKeyDown(Win32.Win32Keyboard.VirtualKeyStates.VK_RETURN))
            {
                EndScene();
            }
        }
    }
}
