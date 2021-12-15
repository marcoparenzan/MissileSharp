using GameConsole.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissileSharp
{
    public struct CrossHairSprite
    {
        public Vec Pos { get; set; }
        public Vec Speed { get; set; }
        public int? Next { get; set; }
        public MouseTrigger MouseTrigger { get; set; }

        public bool MouseTriggered()
        {
            if (MouseTrigger == default) return false;
            return MouseTrigger.Triggered();
        }

        public CrossHairSprite(Vec? pos = null, Vec? speed = null)
        {
            this.Pos = pos ?? (0, 0);
            this.Speed = speed ?? (0, 0);
            this.Next = default;
            this.MouseTrigger = new MouseTrigger();
        }
    }
}
