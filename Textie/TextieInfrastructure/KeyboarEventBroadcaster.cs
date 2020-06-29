using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Textie.TextieInfrastructure
{
    public delegate void KeyDownSciEventHandler(SciKeys key);
    public delegate void KeyDownWinEventHandler(Keys key);
    public static class KeyboarEventBroadcaster
    {
        public static event KeyDownSciEventHandler KeyDownSci;
        public static event KeyDownWinEventHandler KeyDownWin;

        public static void FireKeyDownSci(SciKeys key)
        {
            KeyDownSci?.Invoke(key);
        }
        public static void FireKeyDownWin(Keys key)
        {
            KeyDownWin?.Invoke(key);
        }
    }
}
