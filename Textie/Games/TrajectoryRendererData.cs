using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Textie.Games
{
    public class TrajectoryRendererData
    {
        public TrajectoryRendererData()
        {
        }
        /// <summary>
        /// Property to be used only by the trajectory controller
        /// </summary>
        public int IterationsSinceLastMovement { get; set; }
    }
}
