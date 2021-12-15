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
        private void Initialize(ref CrossHairSprite that)
        {
        }

        private void Render(ref CrossHairSprite that, Graphics g)
        {
            g.DrawImage(spriteSheet, that.Pos.x - 13, that.Pos.y - 13, frames[(int)FrameId.CrossHair], GraphicsUnit.Pixel);
        }

        private void Update(int ms, ref CrossHairSprite that)
        {
            if (that.MouseTriggered()) // if trying to fire
            {
                that.Pos = that.MouseTrigger.Vec.Value;
                that.Next = default;
            }
            else
            {
                that.Next = -1;

            }
        }
    }
}
