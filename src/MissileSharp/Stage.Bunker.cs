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
        static (int x, int y)[] missile_offset = new(int x, int y)[] {
            (0, 18), // 1
            (9, 0), // 2
            (9, 36), // 3
            (-18, 18), // 4
            (-9, 0), // 5
            (18, 18), // 6
            (-9, 36), // 7
            (0, 54), // 8
            (27, 0), // 9
            (-27, 0) // 10
        };

        private void Initialize(int i, ref BunkerSprite that)
        {
        }

        private void Render(int i, ref BunkerSprite that, Graphics g)
        {
            if (that.Next.HasValue) return;

            for (var j = 0; j < that.missiles; j++)
            {
                var offset = missile_offset[j];
                g.DrawImage(spriteSheet, that.Pos.x + offset.x, that.Pos.y - 18 - offset.y, frames[(int)FrameId.AlliedMissileSprite], GraphicsUnit.Pixel);
            }
            if (that.missiles<=3)
                g.DrawString($"LOW", f, Brushes.Red, that.Pos.x, that.Pos.y - 12);
        }

        private void Update(int ms, int i, ref BunkerSprite that)
        {
            if (that.FireTrigger.Triggered()) // if trying to fire
            {
                if (!this.crossHair.MouseTriggered()) return; // no sight!!!!
                if (that.missiles == 0) return; // no missiles!!!
                                                // lock!!!!

                var next = alliedMissiles[nextFreeAlliedMissile].Next.Value;
                alliedMissiles[nextFreeAlliedMissile] = new AlliedMissileSprite((bunkers[i].Pos.x, 550), this.crossHair.Pos);
                nextFreeAlliedMissile = next;

                that.missiles--;
            }
        }
    }
}
