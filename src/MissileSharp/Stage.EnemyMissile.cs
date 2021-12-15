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
        static Pen enemyMissileSpriteTravelPen = new Pen(Color.Red, 3);
        static Brush enemyMissileSpriteExplodeBrush = Brushes.Cyan;
        static Brush enemyMissileSpriteImplodeBrush = Brushes.Gray;

        private void Initialize(int i, ref EnemyMissileSprite that)
        {
        }

        private void Render(int i, ref EnemyMissileSprite that, Graphics g)
        {
            if (that.Next.HasValue) return;

            switch (that.state)
            {
                case EnemyMissileSprite.StateId.Implosion: // implosion
                    g.FillEllipse(enemyMissileSpriteImplodeBrush, that.Pos.x - that.r, that.Pos.y - that.r, 2 * that.r + 1, 2 * that.r + 1);
                    break;
                case EnemyMissileSprite.StateId.Explosion: // explosion
                    g.FillEllipse(enemyMissileSpriteExplodeBrush, that.Pos.x - that.r, that.Pos.y - that.r, 2 * that.r + 1, 2 * that.r + 1);
                    break;
                case EnemyMissileSprite.StateId.Travel:
                    g.DrawLine(enemyMissileSpriteTravelPen, that.Pos.x, that.Pos.y, that.source.x, that.source.y);
                    break;
                default: // no state...delete!
                    break;
            }
        }

        private void Update(int ms, int i, ref EnemyMissileSprite that)
        {
            if (that.Next.HasValue) return;

            switch (that.state)
            {
                case EnemyMissileSprite.StateId.Implosion: // implosion
                    that.r--;
                    that.state = that.r <= 0 ? EnemyMissileSprite.StateId.Dead : EnemyMissileSprite.StateId.Implosion; // evaluate new state
                    // what happens next is not important
                    break;
                case EnemyMissileSprite.StateId.Explosion: // explosion
                    that.r++;
                    that.state = that.r >= 20 ? EnemyMissileSprite.StateId.Implosion : EnemyMissileSprite.StateId.Explosion; // evaluate new state
                    if (that.state == EnemyMissileSprite.StateId.Implosion)
                    {
                        // nothing to do
                    }
                    break;
                case EnemyMissileSprite.StateId.Travel:
                    that.Pos += that.Speed;
                    //if (that.state0.g > that.state0.l) that.source += that.Speed;
                    that.g += that.a;
                    if (that.Pos.y > 640) // out of screen...finished
                    {
                        that.Speed = 0;
                        that.state = EnemyMissileSprite.StateId.Dead;
                        break;
                    }
                    if (CollisionOf(ref that))
                    {
                        that.Speed = 0;
                        that.state = EnemyMissileSprite.StateId.Explosion;
                        lives_count--;
                        break;
                    }
                    break;
                default: // no state...delete!
                    // read to the linked list
                    that.Next = nextFreeEnemyMissile;
                    nextFreeEnemyMissile = i;
                    break;
            }
        }

        bool CollisionOf(ref EnemyMissileSprite that)
        {
            for (var i = 0; i < bunkers.Length; i++)
            {
                if (bunkers[i].Next.HasValue) continue;

                if ((bunkers[i].Pos.y - 30) <= that.Pos.y && Math.Abs(that.Pos.x - bunkers[i].Pos.x) <= 15) // state1...but 2??!?!?!
                {
                    bunkers[i].Next = -1;
                    bunkers_count--;

                    return true;
                }
            }
            for (var i = 0; i < cities.Length; i++)
            {
                if (cities[i].Next.HasValue) continue;

                if ((cities[i].Pos.y - 10) <= that.Pos.y && Math.Abs(that.Pos.x - cities[i].Pos.x)<=15) // state1...but 2??!?!?!
                {
                    cities[i].Next = -1;
                    cities_count--;

                    return true;
                }
            }
            return false;
        }
    }
}
