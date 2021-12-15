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
        private void Initialize(int i, ref CitySprite that)
        {
        }

        private void Render(int i, ref CitySprite that, Graphics g)
        {
            if (that.Next.HasValue) return;

            g.DrawImage(spriteSheet, that.Pos.x - 30, that.Pos.y - 30, frames[(int)FrameId.City], GraphicsUnit.Pixel);
        }

        private void Update(int ms, int i, ref CitySprite that)
        {
        }
    }
}
