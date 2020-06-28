using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Textie.TextieInfrastructure
{
    public delegate void KeyDownEventHandler(SciKeys key);
    public static class KeyboarEventBroadcaster
    {
        public static event KeyDownEventHandler KeyDown;

        public static void FireKeyDown(SciKeys key)
        {
            KeyDown?.Invoke(key);
        }
    }
}
