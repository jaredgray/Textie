using Kbg.NppPluginNET.PluginInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Textie.PluginInfrastructure;
using static Kbg.NppPluginNET.PluginInfrastructure.Win32.Win32Keyboard;

namespace Textie.Games
{
    public class Keyboard
    {
        public Keyboard()
        {
            CurrentKeys = new List<VirtualKeyStates>();
            KeyListeners = new List<VirtualKeyStates>();
        }

        public void ListenTo(VirtualKeyStates keyStates)
        {
            if (!KeyListeners.Contains(keyStates))
                KeyListeners.Add(keyStates);
        }
        private List<VirtualKeyStates> KeyListeners { get; set; }

        private List<VirtualKeyStates> CurrentKeys { get; set; }

        public bool IsKeyDown(VirtualKeyStates key)
        {
            if (null != CurrentKeys)
                return CurrentKeys.Contains(key);
            return false;
        }

        public void Update()
        {
            //CurrentKeys = InputProcessor.ProcessInput();
            //if(null != CurrentKeys)
            //{

            //}
            CurrentKeys.Clear();
            foreach (var keycandidate in KeyListeners)
            {
                if (Win32.Win32Keyboard.IsKeyPressed(keycandidate))
                    CurrentKeys.Add(keycandidate);
            }
        }
    }
}
