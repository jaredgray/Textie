using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Textie.Games
{
    public enum CollisionBehavior
    {
        None,
        Remove,
        RunDestroySequence
    }
    public interface ICollider
    {
        bool HasCollided { get; set; }
        CollisionBehavior CollisionBehavior { get; set; }
        void RunDestroySequence();
    }
}
