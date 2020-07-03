using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Textie.Games
{
    public class RendererData
    {
        public RendererData()
        {
            StepX = StepY = 1;
        }
        public int StepX { get; set; }
        public int StepY { get; set; }
    }
}
