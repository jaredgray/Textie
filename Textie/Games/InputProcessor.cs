using Kbg.NppPluginNET.PluginInfrastructure;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static Kbg.NppPluginNET.PluginInfrastructure.Win32.Win32Keyboard;

namespace Textie.Games
{
    public class InputProcessor
    {

        public static List<VirtualKeyStates> ProcessInput()
        {
            byte[] keys = new byte[256];

            if(Win32.GetKeyboardState(keys))
            {
                List<VirtualKeyStates> downKeys = new List<VirtualKeyStates>();
                
                foreach (var ckey in Enum.GetValues(typeof(VirtualKeyStates)))
                {
                    var selectedKey = keys[(int)ckey];
                    if((selectedKey & 0x80) != 0)
                    {
                        downKeys.Add((VirtualKeyStates)ckey);
                    }
                }

                if(downKeys.Count > 0)
                {
                    return downKeys;
                }
            }
            return null;
        }
    }
}
