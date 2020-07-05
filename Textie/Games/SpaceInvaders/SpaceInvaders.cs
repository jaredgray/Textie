using Kbg.NppPluginNET.PluginInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Textie.Games.Audio;
using Textie.Games.SpaceInvaders;
using Textie.Games.SpaceInvaders.Scenes;
using Textie.TextieInfrastructure;

namespace Textie.Games.Shooter
{
    public class SpaceInvaders : Game<SIScene>
    {
        public SpaceInvaders(INotepadPPGateway npp, IScintillaGateway editor)
            : base(npp, editor)
        {
        }

        protected override void ChangeScene()
        {
            Scene = new PlayGameScene(Editor, Logger, GameSize, GameData);
            Scene.InitializeScene();
        }

        protected override void InitializeInternal()
        {

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
                Scene?.OnLeftKeyDown();
            }
            if (Win32.Keyboard.IsKeyPressed(Win32.Keyboard.VirtualKeyStates.VK_RIGHT))
            {
                Scene?.OnRightKeyDown();
            }
            if (Win32.Keyboard.IsKeyPressed(Win32.Keyboard.VirtualKeyStates.VK_UP))
            {
                Scene?.OnUpKeyDown();
            }
            if (Win32.Keyboard.IsKeyPressed(Win32.Keyboard.VirtualKeyStates.VK_DOWN))
            {
                Scene?.OnDownKeyDown();
            }
            if (Win32.Keyboard.IsKeyPressed(Win32.Keyboard.VirtualKeyStates.VK_SPACE))
            {
                Scene?.OnSpaceKeyDown();
            }
        }

    }
}
