using GameConsole.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsole.Core
{
    public class MouseTrigger
    {
        public Vec? Vec { get; private set; }

        public void Set(Vec vec)
        {
            this.Vec = vec;
        }

        public void Reset()
        {
            this.Vec = default;
        }

        public override string ToString()
        {
            return Vec.ToString() ?? $"(-,-)";
        }

        public bool Triggered() => Vec is not null;

    }
}
