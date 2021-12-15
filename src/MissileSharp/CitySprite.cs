using GameConsole.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissileSharp
{
    public struct CitySprite
    {
        public Vec Pos { get; set; }
        public Vec Speed { get; set; }
        public int? Next { get; set; }

        public CitySprite(Vec pos, Vec? speed = null)
        {
            this.Pos = pos;
            this.Speed = speed ?? (0, 0);
            this.Next = default;
        }
    }
}
