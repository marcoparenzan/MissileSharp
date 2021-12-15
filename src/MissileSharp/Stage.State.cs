using GameConsole.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissileSharp
{
    public partial class Stage
    {
        private StateId state;

        public Stage Ready()
        {
            state = StateId.Ready;
            return this;
        }

        public Stage Running()
        {
            state = StateId.Running;
            return this;
        }

        public Stage LiveLost()
        {
            state = StateId.LiveLost;
            return this;
        }

        public Stage Finished()
        {
            state = StateId.Finished;
            return this;
        }
    }
}
