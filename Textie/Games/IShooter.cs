﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Textie.Games
{
    public interface IShooter
    {
        void FireAtWill(TrajectoryController bulletController, ICollisionController collisionController);
    }
}
