using Kbg.NppPluginNET.PluginInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Textie.TextieInfrastructure;

namespace Textie.Games.Shooter
{
    public class AsciiShooter : Game
    {
        public AsciiShooter(INotepadPPGateway npp, IScintillaGateway editor)
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
            Player = new Sprite(14, 5);
            Player.SetData(PlayerData);
            Player.Bounds.Position.X = 45;
            Player.Bounds.Position.Y = 22;
            base.GameData.Stage.AddSprite(Player);
            //_globalKeyboardHook = new GlobalKeyboardHook();
            //_globalKeyboardHook.KeyboardPressed += _globalKeyboardHook_KeyboardPressed;
            KeyboarEventBroadcaster.KeyDown += KeyboarEventBroadcaster_KeyDown;
        }

        private void KeyboarEventBroadcaster_KeyDown(SciKeys key)
        {
            if (base.IsAlive && base.IsActive)
            {
                base.Try(() =>
                {
                    /*
                        ArrowL - Move left
                        ArrowR - Move right
                        ArrowU - Increase
                        ArrowD - Decrease
                        Space - Fire missile
                        M - Fire super missile
                        B - Fire super bomb
                        N - Fire nuclear bomb
                        Esc - Exit
                     */
                    if (key == SciKeys.Left)
                    {
                        --Player.Bounds.Position.X;
                    }
                    else if (key == SciKeys.Right)
                    {
                        ++Player.Bounds.Position.X;
                    }
                    else if (key == SciKeys.Up)
                    {
                        --Player.Bounds.Position.Y;
                    }
                    else if (key == SciKeys.Down)
                    {
                        ++Player.Bounds.Position.Y;
                    }
                    else if(key == SciKeys.Space)
                    {
                        // fire missile - offsetx = 7
                        var missile = new Bullet(1, Primitives.Direction.Up);
                        missile.Bounds.Position.X = Player.Bounds.Position.X + 7;
                        missile.Bounds.Position.Y = Player.Bounds.Position.Y + 1;// move the missile down by one since the game will move it up on the first iteration of drawing
                        GameData.Stage.AddSprite(missile);
                    }

                    Logger.WriteLine($"Got KeyboardCallback for code {key}");
                });
            }
        }

        protected override void StartGameLoop()
        {

        }

        protected override void StopGameLoop()
        {

        }

        protected override void Update()
        {

        }

    }
}
