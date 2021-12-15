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
        Random rnd = new Random();

        private void Initialize(ref HiddenEnemySprite that)
        {
            that.next = rnd.Next(0, 2000);
        }

        private void Render(ref HiddenEnemySprite that, Graphics g)
        {
        }

        private void Update(int ms, ref HiddenEnemySprite that)
        {
            if (that.next>0)
            {
                that.next -= ms;
                // wait
                return;
            }

            if (that.missiles == 0) 
            {
                // win condition!
                return; // no missiles!!!
            }

                

            var j = rnd.Next(0,9);
            var p2 = j < 3 ? bunkers[j].Pos : cities[j - 3].Pos;
            var next = enemyMissiles[nextFreeEnemyMissile].Next.Value;
            enemyMissiles[nextFreeEnemyMissile] = new EnemyMissileSprite((rnd.Next(10, 950), 0), p2, 2);
            nextFreeEnemyMissile = next;

            that.missiles--;
            that.next = rnd.Next(0, 2000);
        }
    }
}
