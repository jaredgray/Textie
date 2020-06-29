﻿using Kbg.NppPluginNET.PluginInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Textie.TextieInfrastructure;

namespace Textie.Games.Shooter
{
    public class SpaceInvaders : Game
    {
        public SpaceInvaders(INotepadPPGateway npp, IScintillaGateway editor)
            : base(npp, editor)
        {
        }

        readonly string PlayerData = @"      /\      
     /~~\     
 ^  /~~~~\  ^ 
|------------|
|------------|";
        public Sprite Player { get; set; }

        protected override void InitializeInternal()
        {
            Player = new Sprite(14, 5)
            {
                LayerOrder = 0
            };
            Player.SetData(PlayerData);
            Player.Bounds.Position.X = 45;
            Player.Bounds.Position.Y = 22;
            base.GameData.Stage.AddSprite(Player);
            Logger.WriteLine($"Initializing AsciiShooter...");
        }

        protected override void StartGameLoop()
        {

        }

        protected override void StopGameLoop()
        {

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
                --Player.Bounds.Position.X;
            }
            if (Win32.Keyboard.IsKeyPressed(Win32.Keyboard.VirtualKeyStates.VK_RIGHT))
            {
                ++Player.Bounds.Position.X;
            }
            if (Win32.Keyboard.IsKeyPressed(Win32.Keyboard.VirtualKeyStates.VK_UP))
            {
                --Player.Bounds.Position.Y;
            }
            if (Win32.Keyboard.IsKeyPressed(Win32.Keyboard.VirtualKeyStates.VK_DOWN))
            {
                ++Player.Bounds.Position.Y;
            }
            if (Win32.Keyboard.IsKeyPressed(Win32.Keyboard.VirtualKeyStates.VK_SPACE))
            {
                var missile = new Bullet(1, Primitives.Direction.Up)
                {
                    EdgeOfScreenCondition = EdgeScreenHandling.Disappear,
                    LayerOrder = int.MaxValue
                };
                missile.Bounds.Position.X = Player.Bounds.Position.X + 7;
                missile.Bounds.Position.Y = Player.Bounds.Position.Y + 1;// move the missile down by one since the game will move it up on the first iteration of drawing
                GameData.Stage.AddSprite(missile);
            }
        }

    }
}