using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Textie.Games.Primitives
{
    public class Size
    {
        public Size() { }
        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public int Width { get; set; }
        public int Height { get; set; }

    }
}
