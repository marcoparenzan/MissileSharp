using GameConsole.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissileSharp
{
    public struct EnemyMissileSprite
    {
        public Vec Pos { get; set; }
        public Vec source { get; set; }
        internal StateId state;
        internal Vec sv;
        internal int d;
        internal int l;
        internal int g;
        internal int a;
        internal int r;

        public Vec Speed { get; set; }
        public int? Next { get; set; }

        internal enum StateId
        {
            Travel,
            Explosion,
            Implosion,
            Dead
        }

        public EnemyMissileSprite(Vec source, Vec target, int a = 15)
        {
            this.Pos = source;
            this.source = this.Pos;
            this.state = 0;
            this.sv = (target - source);
            this.d = (int)sv.M;
            this.l = 3;
            this.g = 0;
            this.a = a;
            this.r = 1;
            this.Speed = this.sv * this.a / this.d; // AARRGGHHH!!!!!!!
            this.Next = default;
        }
    }
}
