using GameConsole.Core;
using System;

namespace MissileSharp
{
    public struct HiddenEnemySprite
    {
        internal int missiles;
        internal int next;

        public HiddenEnemySprite(int missiles)
        {
            this.missiles = missiles;
            this.next = -1;
        }
    }
}
